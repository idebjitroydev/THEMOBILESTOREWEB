using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Location_Management_Add_City : System.Web.UI.Page
{
    private Cities c = new Cities();
    private Helpers h = new Helpers();

    #region PAGE LOAD EVENT

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDown();
        }
        popup.Visible = popupDanger.Visible = false;
    }

    #endregion PAGE LOAD EVENT

    #region FILL STATES DROPDOWN

    protected void FillDropDown()
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "SELECT ID, Name FROM tbl_states ORDER BY Name ASC";
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpState.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                    drpState.DataValueField = ds.Tables[0].Columns["Name"].ToString();
                    drpState.DataSource = ds.Tables[0];
                    drpState.DataBind();
                }
            }
            catch (Exception ex)
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "Oops There's Something wrong. <strong>" + ex.Message + "</strong>";
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL STATES DROPDOWN

    #region BACK BUTTON CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Location-Management/All-Cities.aspx");
    }

    #endregion BACK BUTTON CLICK EVENT

    #region SAVE BUTTON CLICK EVENT

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            c.Name = txtName.Text.ToUpper().Trim();
            c.State = drpState.SelectedValue.ToString();
            c.created_at = DateTime.Now;
            bool isSuccess = c.Insert();
            if (isSuccess == true)
            {
                popup.Visible = true;
                message.InnerHtml = "City Saved Successfully.";
                Clear();
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "Oops Something Went Wrong, City Fail to Save. <strong>" + c.Error + "</strong>";
            }
        }
    }

    #endregion SAVE BUTTON CLICK EVENT

    #region CUSTOM VALIDATION TO CHECK IF EXISTS

    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (h.CheckName("tbl_cities", "Name", args.Value) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    #endregion CUSTOM VALIDATION TO CHECK IF EXISTS

    #region CLEAR METHOD

    protected void Clear()
    {
        txtName.Text = "";
        //drpState.ClearSelection();
    }

    #endregion CLEAR METHOD
}