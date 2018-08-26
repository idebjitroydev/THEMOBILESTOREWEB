using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_User_Management_All_Employees : System.Web.UI.Page
{
    private Helpers h = new Helpers();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDataGrid();
        }
        popup.Visible = popupDanger.Visible = false;

        if (Request.QueryString["success"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessDeleted("Employee");
        }

        if (Request.QueryString["reseted"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessMessage("Employee", "Successfully Reseted Table");
        }
    }

    #endregion PAGE LOAD

    #region BUTTON TRUNCATE CLICK EVENT

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool isReset = h.Truncate("tbl_employees");
            if (isReset == false)
            {
                Response.Redirect("~/Admin/User-Management/All-Employees.aspx?reseted=true");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrorDelete("Employee", h.Error);
            }
        }
    }

    #endregion BUTTON TRUNCATE CLICK EVENT

    #region FILL DATAGRID

    public void FillDataGrid()
    {
        DataSet dt = h.Select("tbl_employees", "Name");
        if (dt.Tables[0].Rows.Count > 0)
        {
            dgEmp.DataSource = dt;
            dgEmp.DataBind();
        }
    }

    #endregion FILL DATAGRID

    #region RESET KEYWORD VALIDATION EVENT

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

    #endregion RESET KEYWORD VALIDATION EVENT

    #region BUTTON EDIT CLICK EVENT

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lb.Parent.Parent;
        hdid.Value = ((HiddenField)gvr.FindControl("hdID")).Value.ToString();
        string ENID = Helpers.Encode(hdid.Value);
        Response.Redirect("~/Admin/User-Management/Edit-Employee.aspx?id=" + ENID);
    }

    #endregion BUTTON EDIT CLICK EVENT

    #region PAGINATION EVENT

    protected void dgStates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgEmp.PageIndex = e.NewPageIndex;
        FillDataGrid();
    }

    #endregion PAGINATION EVENT
}