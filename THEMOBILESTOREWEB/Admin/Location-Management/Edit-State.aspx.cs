using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Location_Management_Edit_State : System.Web.UI.Page
{
    private States s = new States();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"].ToString());
        int ID = Convert.ToInt32(DCID);
        if (!IsPostBack)
        {
            FillData(ID);
        }
        popupDanger.Visible = false;
        popup.Visible = false;
    }

    #endregion PAGE LOAD

    #region FILL DATA IN TEXTBOX

    protected void FillData(int ID)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(Database.connection);
        using (conn)
        {
            try
            {
                string query = "SELECT Name FROM tbl_states WHERE ID = @ID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "<strong>" + ex.Message + "</strong>";
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL DATA IN TEXTBOX

    #region BUTTON UPDATE CLICK EVENT

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string DCID = Helpers.Decode(Request.QueryString["id"].ToString());
            int ID = Convert.ToInt32(DCID);
            s.ID = ID;
            s.Name = txtName.Text.ToUpper().Trim();
            s.updated_at = DateTime.Now;

            bool isSuccess = s.Update();

            if (isSuccess == true)
            {
                popup.Visible = true;
                message.InnerHtml = "State Updated Succesfully";
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "State Update Failed. <strong>" + s.Error + "</strong>";
            }
        }
    }

    #endregion BUTTON UPDATE CLICK EVENT

    #region BUTTON BACK CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Location-Management/All-States.aspx");
    }

    #endregion BUTTON BACK CLICK EVENT

    #region CUSTOM VALIDATION EVENT

    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (s.CheckName(args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    #endregion CUSTOM VALIDATION EVENT

    #region BUTTON DELETE CLICK EVENT

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"].ToString());
        s.ID = Convert.ToInt32(DCID);
        bool isSuccess = s.Delete();
        if (isSuccess == true)
        {
            Response.Redirect("~/Admin/Location-Management/All-States.aspx?state-delete=success");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = "State Delete Failed. <strong>" + s.Error + "</strong>";
        }
    }

    #endregion BUTTON DELETE CLICK EVENT
}