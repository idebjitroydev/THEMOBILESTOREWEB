using System;

public partial class Admin_Product_Management_Add_Category : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Category c = new Category();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAccountNumber.Text = h.GenerateAccountNumber("tbl_categories", "CAT");
        }

        if (Request.QueryString["success"] == "true")
        {
        }

        popup.Visible = popupDanger.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            c.Category_No = txtAccountNumber.Text;
            c.Name = h.Format(txtName.Text);
            c.created_at = DateTime.Now;
            c.created_by = "Debjit Roy";
            c.Status = "Active";
            bool insert = c.Insert();
            if (insert == true)
            {
                popup.Visible = true;
                message.InnerHtml = h.SuccessSaved("Category");
                txtAccountNumber.Text = h.GenerateAccountNumber("tbl_categories", "CAT");
                txtName.Text = "";
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrorSaved("Category", c.Error);
            }
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = "<strong>Oops!</strong> It Seems, there's some problem validating the data.";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        h.Redirect("~/Admin/Product-Management/All-Categories.aspx");
    }

    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (h.CheckName("tbl_categories", "Name", args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}