using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Product_Management_Add_Products : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Products p = new Products();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillBrand();
            FillCat();
        }
        popup.Visible = popupDanger.Visible = false;
        txtAccountNumber.Text = h.GenerateAccountNumber("tbl_products", "PRD");
        txtStock.Text = "0";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        h.Redirect("~/Admin/Product-Management/All-Products.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        p.Product_No = txtAccountNumber.Text;
        p.Name = h.Format(txtName.Text);
        p.Code = txtCode.Text;
        p.Barcode = txtBarcode.Text;
        p.CostPrice = Convert.ToDecimal(txtCP.Text);
        p.SellingPrice = Convert.ToDecimal(txtSP.Text);
        p.Discount = Convert.ToDecimal(txtDiscount.Text);
        p.created_at = DateTime.Now;
        p.created_by = "Debjit Roy";
        p.Stock = Convert.ToInt32(txtStock.Text);
        p.created_com_name = h.GetClientComputerName();
        p.Brand = drpBrand.SelectedValue.ToString();
        p.Category = drpCat.SelectedValue.ToString();
        p.Status = "Out Of Stock";
        bool save = p.Insert();
        if (save == true)
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessSaved("Product");
            txtAccountNumber.Text = h.GenerateAccountNumber("tbl_products", "PRD");
            Clear();
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorSaved("Product", p.Error);
        }
    }

    protected void Clear()
    {
        txtName.Text = txtCode.Text = txtBarcode.Text = txtCP.Text = txtSP.Text = txtDiscount.Text = "";
        drpBrand.ClearSelection();
        drpCat.ClearSelection();
    }

    protected void FillBrand()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string sql = "SELECT NAME FROM tbl_brands";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataSet ds = new DataSet();
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpBrand.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                    drpBrand.DataValueField = ds.Tables[0].Columns["Name"].ToString();
                    drpBrand.DataSource = ds;
                    drpBrand.DataBind();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Brand", ex.Message, "Fail to Load");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    protected void FillCat()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string sql = "SELECT NAME FROM tbl_categories";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataSet ds = new DataSet();
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpCat.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                    drpCat.DataValueField = ds.Tables[0].Columns["Name"].ToString();
                    drpCat.DataSource = ds;
                    drpCat.DataBind();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Categories", ex.Message, "Fail to Load");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (h.CheckName("tbl_products", "Name", args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}