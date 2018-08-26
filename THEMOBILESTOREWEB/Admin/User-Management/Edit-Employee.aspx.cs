using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_User_Management_Edit_Employee : System.Web.UI.Page
{
    private Employees em = new Employees();
    private Helpers h = new Helpers();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
            FillCityDropdown();
        }
        popup.Visible = popupDanger.Visible = false;
    }

    #endregion PAGE LOAD

    #region FILL DATA IN TEXTBOX

    public void FillData()
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "SELECT * FROM tbl_employees WHERE ID =@ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(DCID));
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAccountNumber.Text = ds.Tables[0].Rows[0]["Account_No"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    drpCity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                    drpGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    drpType.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
                    drpStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Employee", ex.Message, "Failed to Load");
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

    #region UPDATE BUTTON CLICK EVENT

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string DID = Helpers.Decode(Request.QueryString["ID"]);
        em.ID = Convert.ToInt32(DID);
        em.Account_No = txtAccountNumber.Text;
        em.Name = h.Format(txtName.Text);
        em.Email = txtEmail.Text;
        em.Phone = txtPhone.Text;
        em.Address = txtAddress.Text;
        em.City = drpCity.SelectedValue;
        em.State = txtState.Text;
        em.Pincode = txtPincode.Text;
        em.Country = txtCountry.Text;
        em.Gender = drpGender.SelectedValue;
        em.Type = drpType.SelectedValue;
        em.Status = drpStatus.SelectedValue;
        em.updated_at = DateTime.Now;
        em.updated_by = "Debjit Roy";
        em.updated_com_name = h.GetClientComputerName();
        bool isUpdated = em.Update();
        if (isUpdated == true)
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessUpdated("Employee");
        }
        else
        {
            popupDanger.Visible = true;
            message.InnerHtml = h.ErrorUpdate("Employee", em.Error);
        }
    }

    #endregion UPDATE BUTTON CLICK EVENT

    #region BACK BUTTON CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/User-Management/All-Employees.aspx");
    }

    #endregion BACK BUTTON CLICK EVENT

    #region BUTTON DELETE CLICK EVENT

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        bool Deleted = h.Delete("tbl_employees", Convert.ToInt32(DCID));
        if (Deleted == true)
        {
            Response.Redirect("~/Admin/User-Management/All-Employees.aspx?success=true");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorDelete("Employee", h.Error);
        }
    }

    #endregion BUTTON DELETE CLICK EVENT

    #region CHANGE PASSWORD BUTTON CLICK EVENT

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string DID = Helpers.Decode(Request.QueryString["id"]);
            em.ID = Convert.ToInt32(DID);
            em.Password = Helpers.Encode(txtPassword.Text);
            bool Changed = em.ChangePassword();

            if (Changed == true)
            {
                popup.Visible = true;
                message.InnerHtml = h.SuccessMessage("Employee", "Password Changed Successfully");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Employee", em.Error, "Failed To Change Password");
            }
        }
    }

    #endregion CHANGE PASSWORD BUTTON CLICK EVENT
}