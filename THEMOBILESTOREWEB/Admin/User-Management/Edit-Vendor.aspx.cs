using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_User_Management_Edit_Vendor : System.Web.UI.Page
{
    private Vendors v = new Vendors();
    private Helpers h = new Helpers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
            FillCityDropdown();
        }

        popup.Visible = popupDanger.Visible = false;
    }

    #region FILL DATA IN TEXTBOX

    public void FillData()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "SELECT * FROM tbl_vendors WHERE ID=@ID";
                string DCID = Helpers.Decode(Request.QueryString["id"]);
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(DCID));
                DataSet ds = new DataSet();
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAccountNumber.Text = ds.Tables[0].Rows[0]["Account_No"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtPhone2.Text = ds.Tables[0].Rows[0]["Phone2"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                    txtGST.Text = ds.Tables[0].Rows[0]["GSTNo"].ToString();
                    txtAadhar.Text = ds.Tables[0].Rows[0]["Aadhar"].ToString();
                    txtLicense.Text = ds.Tables[0].Rows[0]["License"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    drpCity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
                    drpBrand.SelectedValue = ds.Tables[0].Rows[0]["Brand"].ToString();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Vendor", ex.Message, "Failed to Fill Data");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL DATA IN TEXTBOX

    #region FILL CITY DROPDOWN

    public void FillCityDropdown()
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "SELECT Name,State FROM tbl_cities ORDER BY Name ASC";
                SqlCommand cmd = new SqlCommand(qry, conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpCity.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                    drpCity.DataValueField = ds.Tables[0].Columns["Name"].ToString();
                    drpCity.DataSource = ds.Tables[0];
                    drpCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Cities", ex.Message, "Error Filling DropDown");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL CITY DROPDOWN

    #region FILL STATES TEXT BOX

    protected void drpCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "SELECT Name, State FROM tbl_cities WHERE Name=@Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", drpCity.SelectedValue.ToString());
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("States", ex.Message, "Failed To Load");
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL STATES TEXT BOX

    #region BUTTON UPDATE CLICK EVENT

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string DID = Helpers.Decode(Request.QueryString["id"]);
            v.ID = Convert.ToInt32(DID);
            v.Account_No = txtAccountNumber.Text;
            v.Name = h.Format(txtName.Text);
            v.Email = txtEmail.Text;
            v.Phone = txtPhone.Text;
            v.Phone2 = txtPhone2.Text;
            v.Address = txtAddress.Text;
            v.City = drpCity.SelectedValue.ToString();
            v.State = txtState.Text;
            v.Pincode = txtPincode.Text;
            v.Country = txtCountry.Text;
            v.GSTNo = txtGST.Text;
            v.License = txtLicense.Text;
            v.Aadhar = txtAadhar.Text;
            v.Brand = drpBrand.SelectedValue.ToString();
            v.updated_at = DateTime.Now;
            v.updated_by = "Debjit Roy";
            v.updated_com_name = h.GetClientComputerName();
            v.Status = "Active";
            v.Brand = drpBrand.SelectedValue.ToString();
            bool insert = v.Update();
            if (insert == true)
            {
                popup.Visible = true;
                message.InnerHtml = h.SuccessUpdated("Vendor");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrorUpdate("Vendor", v.Error);
            }
        }
    }

    #endregion BUTTON UPDATE CLICK EVENT

    #region BACK BUTTON CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        h.Redirect("~/Admin/User-Management/All-Vendors.aspx");
    }

    #endregion BACK BUTTON CLICK EVENT

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        bool Deleted = h.Delete("tbl_vendors", Convert.ToInt32(DCID));
        if (Deleted == true)
        {
            h.Redirect("~/Admin/User-Management/All-Vendors.aspx?success=true");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorDelete("Employee", h.Error);
        }
    }
}