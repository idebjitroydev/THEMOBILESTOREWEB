using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_Location_Management_All_States : System.Web.UI.Page
{
    private States s = new States();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        popup.Visible = false;
        popupDanger.Visible = false;
        if (!IsPostBack)
        {
            Fill();
        }
        if (Request.QueryString["msg"] == "success")
        {
            popup.Visible = true;
            message.InnerHtml = "All States Reseted Successfully";
        }

        if (Request.QueryString["state-delete"] == "success")
        {
            popup.Visible = true;
            message.InnerHtml = "State Deleted Successfully";
        }
    }

    #endregion PAGE LOAD

    #region FILL DATAGRID

    public void Fill()
    {
        DataSet ds = s.Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgStates.DataSource = ds;
            dgStates.DataBind();
        }
    }

    #endregion FILL DATAGRID

    #region BUTTON EDIT CLICK EVENT

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lb.Parent.Parent;
        hdid.Value = ((HiddenField)gvr.FindControl("hdID")).Value.ToString();
        string enID = Helpers.Encode(hdid.Value);
        Response.Redirect("~/Admin/Location-Management/Edit-State.aspx?id=" + enID);
    }

    #endregion BUTTON EDIT CLICK EVENT

    #region BUTTON TRUNCATE CLICK EVENT

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool reseted = s.Truncate();
            if (reseted == true)
            {
                //popup.Visible = true;
                //message.InnerHtml = "All States Reseted Successfully";

                Response.Redirect("~/Admin/Location-Management/All-States.aspx?msg=success");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "Reset Failed. <strong>" + s.Error + "</strong>";
            }
        }
    }

    #endregion BUTTON TRUNCATE CLICK EVENT

    #region RESET TEXT CUSTOM VALIDATION EVENT

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

    #endregion RESET TEXT CUSTOM VALIDATION EVENT

    #region PAGE INDEX CHANGING PAGINATION EVENT

    protected void dgStates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgStates.PageIndex = e.NewPageIndex;
        Fill();
    }

    #endregion PAGE INDEX CHANGING PAGINATION EVENT
}