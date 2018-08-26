using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_Location_Management_All_Cities : System.Web.UI.Page
{
    private Helpers h = new Helpers();
    private Cities c = new Cities();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        Fill();
        popup.Visible = popupDanger.Visible = false;

        if (Request.QueryString["reset"] == "success")
        {
            popup.Visible = true;
            message.InnerHtml = "<strong>Yippie!</strong> Data Reseted Successfully";
        }

        if (Request.QueryString["deleted"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessDeleted("City");
        }
    }

    #endregion PAGE LOAD

    #region FILL DATA IN DATAGRID

    protected void Fill()
    {
        DataSet ds = c.Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            dgCities.DataSource = ds;
            dgCities.DataBind();
        }
    }

    #endregion FILL DATA IN DATAGRID

    #region EDIT BUTTON CLICK EVENT

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lb.Parent.Parent;
        hdid.Value = ((HiddenField)gvr.FindControl("hdID")).Value.ToString();
        string enID = Helpers.Encode(hdid.Value);
        Response.Redirect("~/Admin/Location-Management/Edit-City.aspx?id=" + enID);
    }

    #endregion EDIT BUTTON CLICK EVENT

    #region RESET TEXT VALIDTION

    protected void ResetValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value == "Reset")
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    #endregion RESET TEXT VALIDTION

    #region TRUNCATE TABLE BUTTON CLICK EVENT

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool isSuccess = h.Truncate("tbl_cities");
            if (isSuccess == false)
            {
                Response.Redirect("~/Admin/Location-Management/All-Cities.aspx?reset=success");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "Oops, Something went wrong while reseting <strong>" + h.Error + "</strong>";
            }
        }
    }

    #endregion TRUNCATE TABLE BUTTON CLICK EVENT

    #region PAGER PAGE INDEX CHANGING EVENT

    protected void dgCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgCities.PageIndex = e.NewPageIndex;
        Fill();
    }

    #endregion PAGER PAGE INDEX CHANGING EVENT
}