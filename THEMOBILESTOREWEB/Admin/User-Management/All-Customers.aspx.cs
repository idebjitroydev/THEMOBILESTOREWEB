using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_User_Management_All_Vendors : System.Web.UI.Page
{
    private Helpers h = new Helpers();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
        popup.Visible = popupDanger.Visible = false;

        if (Request.QueryString["reset"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessMessage("Customers", "Table Successfully Reseted");
        }

        if (Request.QueryString["success"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessDeleted("Customer");
        }
    }

    #endregion PAGE LOAD

    #region FILL DATAGRID

    public void FillData()
    {
        DataSet ds = h.Select("tbl_customers", "Name");
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgVendors.DataSource = ds;
            dgVendors.DataBind();
        }
    }

    #endregion FILL DATAGRID

    #region BUTTON TRUNCATE CLICK EVENT

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool reset = h.Truncate("tbl_customers");
            if (reset == false)
            {
                Response.Redirect("~/Admin/User-Management/All-Customers.aspx?reset=true");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Customer", h.Error, "Table Reset Failed");
            }
        }
    }

    #endregion BUTTON TRUNCATE CLICK EVENT

    #region EDIT BUTTON CLICK EVENT

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lb.Parent.Parent;
        hdid.Value = ((HiddenField)gvr.FindControl("hdID")).Value.ToString();
        string ENID = Helpers.Encode(hdid.Value);
        Response.Redirect("~/Admin/User-Management/Edit-Customer.aspx?id=" + ENID);
    }

    #endregion EDIT BUTTON CLICK EVENT

    #region PAGINATION CLICK EVENT

    protected void dgVendors_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        dgVendors.PageIndex = e.NewPageIndex;
        FillData();
    }

    #endregion PAGINATION CLICK EVENT

    #region RESET KEYWORD VALIDATOR CLICK EVENT

    protected void ResetValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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

    #endregion RESET KEYWORD VALIDATOR CLICK EVENT
}