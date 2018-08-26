using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_Product_Management_All_Products : System.Web.UI.Page
{
    private Helpers h = new Helpers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataFill();
        }
        popup.Visible = popupDanger.Visible = false;
        if (Request.QueryString["reset"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessMessage("Products", "Table Reseted Succesfully");
        }

        if (Request.QueryString["delete"] == "true")
        {
            popup.Visible = true;
            message.InnerHtml = h.SuccessDeleted("Product");
        }
    }

    protected void DataFill()
    {
        DataSet ds = h.Select("tbl_products", "Name");
        dgProducts.DataSource = ds;
        dgProducts.DataBind();
    }

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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lb.Parent.Parent;
        hdid.Value = ((HiddenField)gvr.FindControl("hdID")).Value.ToString();
        string ENID = Helpers.Encode(hdid.Value);
        h.Redirect("~/Admin/Product-Management/Edit-Product.aspx?id=" + ENID);
    }

    protected void dgProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgProducts.PageIndex = e.NewPageIndex;
        DataFill();
    }

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool reset = h.Truncate("tbl_products");
            if (reset == false)
            {
                h.Redirect("~/Admin/Product-Management/All-Products.aspx?reset=true");
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = h.ErrMessage("Product", h.Error, "Table Reset failed.");
            }
        }
    }
}