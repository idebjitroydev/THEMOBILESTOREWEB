using System;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Location_Management_Edit_City : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Cities c = new Cities();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            FillDropDown();
            FillData(Convert.ToInt32(DCID));
        }
        popup.Visible = popupDanger.Visible = false;
    }

    #endregion PAGE LOAD

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

    #region FILL TEXTBOX

    public void FillData(int ID)
    {
        DataTable ds = new DataTable();
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "SELECT Name, State FROM tbl_cities WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);

                if (ds.Rows.Count > 0)
                {
                    txtName.Text = ds.Rows[0]["Name"].ToString();
                    drpState.SelectedValue = ds.Rows[0]["State"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }

    #endregion FILL TEXTBOX

    #region BUTTON SAVE CLICK EVENT

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string DCID = Helpers.Decode(Request.QueryString["id"]);
            c.ID = Convert.ToInt32(DCID);
            c.Name = txtName.Text;
            c.State = drpState.SelectedValue.ToString();
            c.updated_at = DateTime.Now;
            bool isSuccess = c.Update();
            if (isSuccess == true)
            {
                popup.Visible = true;
                message.InnerHtml = "<strong>Yippie!</strong> City Updated Successfully";
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "<strong>Oops!</strong> Something went wrong while updating. " + c.Error;
            }
        }
    }

    #endregion BUTTON SAVE CLICK EVENT

    #region BUTTON BACK CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Location-Management/All-Cities.aspx");
    }

    #endregion BUTTON BACK CLICK EVENT

    #region DELETE BUTTON CLICK EVENT

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string DCID = Helpers.Decode(Request.QueryString["id"]);
        bool isDeleted = h.Delete("tbl_cities", Convert.ToInt32(DCID));
        if (isDeleted == true)
        {
            Response.Redirect("~/Admin/Location-Management/All-Cities.aspx?deleted=true");
        }
        else
        {
            popupDanger.Visible = true;
            errMessage.InnerHtml = h.ErrorDelete("City", h.Error);
        }
    }

    #endregion DELETE BUTTON CLICK EVENT
}