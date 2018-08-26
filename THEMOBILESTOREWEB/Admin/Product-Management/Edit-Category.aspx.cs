using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Product_Management_Edit_Category : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Category c = new Category();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
        popup.Visible = false;
        popupDanger.Visible = false;
    }

    protected void FillData()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            string qry = "SELECT * FROM tbl_categories WHERE ID= @ID";
            SqlCommand cmd = new SqlCommand(qry, conn);
            string DCID = Helpers.Decode(Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(DCID));
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAccountNumber.Text = ds.Tables[0].Rows[0]["Category_No"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                drpStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        c.ID = Convert.ToInt32(DCID);
        c.Category_No = txtAccountNumber.Text;
        c.Name = txtName.Text;
        c.updated_at = DateTime.Now;
        c.updated_by = "Debjit Roy";
        c.Status = drpStatus.SelectedValue.ToString();
        bool updated = c.Update();
        if (updated == true)
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessUpdated("Category");
        }
        else
        {
            popupDanger.Visible = false;
            errMessage.InnerHtml = h.ErrorUpdate("Category", c.Error);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        h.Redirect("~/Admin/Product-Management/All-Categories.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        bool Deleted = h.Delete("tbl_categories", Convert.ToInt32(DCID));

        if (Deleted == true)
        {
            h.Redirect("~/Admin/Product-Management/All-Categories.aspx?delete=true");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorDelete("Category", h.Error);
        }
    }
}