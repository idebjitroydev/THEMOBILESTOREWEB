using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_User_Management_Add_Employee : System.Web.UI.Page
{
    public Helpers h = new Helpers();
    private Employees em = new Employees();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAccountNumber.Text = h.GenerateAccountNumber("tbl_employees", "EMP");
            FillCityDropdown();
        }
        popup.Visible = popupDanger.Visible = false;
        txtAccountNumber.ReadOnly = true;
        txtCountry.Text = "INDIA";
        txtCountry.ReadOnly = true;
    }

    #endregion PAGE LOAD

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

    #region BUTTON SAVE CLICK EVENT

    protected void btnSave_Click(object sender, EventArgs e)
    {
        em.Account_No = txtAccountNumber.Text;
        em.Name = h.Format(txtName.Text);
        em.Email = txtEmail.Text;
        em.Password = Helpers.Encode(txtPass.Text);
        em.Phone = txtPhone.Text.Trim();
        em.Address = txtAddress.Text.Trim();
        em.City = drpCity.SelectedValue.ToString();
        em.State = txtState.Text;
        em.Pincode = txtPincode.Text.Trim();
        em.Country = txtCountry.Text;
        em.Gender = drpGender.SelectedValue.ToUpper().ToString();
        em.created_at = DateTime.Now;
        em.created_by = "Debjit Roy";
        em.created_com_name = h.GetClientComputerName();
        em.Type = drpType.SelectedValue.ToString();
        em.Status = "Active";
        bool isSuccess = em.Insert();
        if (isSuccess == true)
        {
            Clear();
            popup.Visible = true;
            message.InnerHtml = h.SuccessSaved("Employee");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorSaved("Employee", em.Error);
        }
    }

    #endregion BUTTON SAVE CLICK EVENT

    #region BUTTON BACK CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/User-Management/All-Employees.aspx");
    }

    #endregion BUTTON BACK CLICK EVENT

    #region CLEAR EVENT

    public void Clear()
    {
        txtName.Text = txtAddress.Text = txtEmail.Text = txtPhone.Text = txtState.Text = txtPincode.Text = "";
        drpCity.ClearSelection();
        drpGender.ClearSelection();
        drpType.ClearSelection();
    }

    #endregion CLEAR EVENT
}