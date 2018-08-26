using System;

public partial class Admin_Dashboard : System.Web.UI.Page
{
    private Helpers h = new Helpers();

    protected void Page_Load(object sender, EventArgs e)
    {
        cstCard.InnerHtml = h.Count("tbl_customers");
        vendorsCard.InnerHtml = h.Count("tbl_vendors");
        prdCard.InnerHtml = h.Count("tbl_products");
        empCard.InnerHtml = h.Count("tbl_employees");
        brandCard.InnerHtml = h.Count("tbl_brands");
        catCard.InnerHtml = h.Count("tbl_categories");
    }
}