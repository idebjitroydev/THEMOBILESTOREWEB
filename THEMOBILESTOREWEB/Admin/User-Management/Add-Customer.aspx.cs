using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_User_Management_Add_Vendor : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Customer v = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCityDropdown();
        }
        popup.Visible = popupDanger.Visible = false;
        txtCountry.Text = "INDIA";
        txtAccountNumber.Text = h.GenerateAccountNumber("tbl_customers", "CST");
    }

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

    #region SAVE BUTTON CLICK EVENT

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            v.Account_No = txtAccountNumber.Text;
            v.Name = h.Format(txtName.Text);
            v.Email = txtEmail.Text;
            v.Phone = txtPhone.Text;
            v.Address = txtAddress.Text;
            v.City = drpCity.SelectedValue.ToString();
            v.State = txtState.Text;
            v.Pincode = txtPincode.Text;
            v.Country = txtCountry.Text;
            v.Type = drpType.SelectedValue.ToString();
            v.created_at = DateTime.Now;
            v.created_by = "Debjit Roy";
            v.created_com_name = h.GetClientComputerName();
            v.Status = "Active";
            bool insert = v.Insert();
            if (insert == true)
            {
                Clear();
                popup.Visible = true;
                message.InnerHtml = h.SuccessSaved("Customer");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrorSaved("Customer", v.Error);
            }
        }
    }

    #endregion SAVE BUTTON CLICK EVENT

    #region BACK BUTTON CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/User-Management/All-Customers.aspx");
    }

    #endregion BACK BUTTON CLICK EVENT

    #region CLEAR FORM

    public void Clear()
    {
        txtName.Text = txtEmail.Text = txtPhone.Text = txtAddress.Text = txtState.Text = txtPincode.Text = "";
        drpType.ClearSelection();
        drpCity.ClearSelection();
    }

    #endregion CLEAR FORM
}