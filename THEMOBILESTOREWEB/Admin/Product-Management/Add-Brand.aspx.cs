using System;

public partial class Admin_Product_Management_Add_Category : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Brands b = new Brands();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAccountNumber.Text = h.GenerateAccountNumber("tbl_brands", "BRD");
        }

        popup.Visible = popupDanger.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            b.Account_No = txtAccountNumber.Text;
            b.Name = h.Format(txtName.Text);
            b.Email = txtEmail.Text;
            b.created_at = DateTime.Now;
            b.created_by = "Debjit Roy";
            b.created_com_name = h.GetClientComputerName();
            b.Status = "Active";
            bool insert = b.Insert();
            if (insert == true)
            {
                popup.Visible = true;
                message.InnerHtml = h.SuccessSaved("Brand");
                txtAccountNumber.Text = h.GenerateAccountNumber("tbl_brands", "BRD");
                txtName.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrorSaved("Brand", b.Error);
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
        h.Redirect("~/Admin/Product-Management/All-Brands.aspx");
    }

    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (h.CheckName("tbl_brands", "Name", args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void CustomValidator2_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (h.CheckName("tbl_brands", "Email", args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}