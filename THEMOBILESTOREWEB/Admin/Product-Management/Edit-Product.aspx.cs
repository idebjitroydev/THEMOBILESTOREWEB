using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Product_Management_Edit_Products : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Products p = new Products();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillBrand();
            FillCat();
            FillData();
        }
        popup.Visible = popupDanger.Visible = false;
    }

    protected void FillData()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string sql = "SELECT * FROM tbl_products WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                string DCID = Helpers.Decode(Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(DCID));
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAccountNumber.Text = ds.Tables[0].Rows[0]["Product_No"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                    txtBarcode.Text = ds.Tables[0].Rows[0]["Barcode"].ToString();
                    txtCP.Text = ds.Tables[0].Rows[0]["CostPrice"].ToString();
                    txtSP.Text = ds.Tables[0].Rows[0]["SellingPrice"].ToString();
                    txtStock.Text = ds.Tables[0].Rows[0]["Stock"].ToString();
                    txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                    drpBrand.SelectedValue = ds.Tables[0].Rows[0]["Brand"].ToString();
                    drpCat.SelectedValue = ds.Tables[0].Rows[0]["Category"].ToString();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Product", ex.Message, "An Unexpected Error Occured.");
            }
            finally
            {
                conn.Close();
            }
        }
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        bool Deleted = h.Delete("tbl_products", Convert.ToInt32(DCID));

        if (Deleted == true)
        {
            h.Redirect("~/Admin/Product-Management/All-Products.aspx?delete=true");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorDelete("Product", h.Error);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtStock.Text) < 2)
        {
            p.Status = "Out Of Stock";
        }
        else
        {
            p.Status = "Avialable";
        }
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        p.ID = Convert.ToInt32(DCID);
        p.Product_No = txtAccountNumber.Text;
        p.Name = h.Format(txtName.Text);
        p.Code = txtCode.Text;
        p.Barcode = txtBarcode.Text;
        p.Category = drpCat.SelectedValue.ToString();
        p.Brand = drpBrand.SelectedValue.ToString();
        p.CostPrice = Convert.ToDecimal(txtCP.Text);
        p.SellingPrice = Convert.ToDecimal(txtSP.Text);
        p.Stock = Convert.ToInt32(txtStock.Text);
        p.Discount = Convert.ToDecimal(txtDiscount.Text);
        p.updated_at = DateTime.Now;
        p.updated_by = "Debjit Roy";
        p.updated_com_name = h.GetClientComputerName();
        bool updated = p.Update();
        if (updated == true)
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessUpdated("Product");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorUpdate("Product", p.Error);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        h.Redirect("~/Admin/Product-Management/All-Products.aspx");
    }
}