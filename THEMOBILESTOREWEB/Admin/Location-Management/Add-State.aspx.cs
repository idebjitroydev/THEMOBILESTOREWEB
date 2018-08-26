using System;

public partial class Admin_Location_Management_Add_State : System.Web.UI.Page
{
    private States s = new States();

    #region PAGE LOAD

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        popup.Visible = false;
        popupDanger.Visible = false;
    }

    #endregion PAGE LOAD

    #region BACK BUTTON CLICK EVENT

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Location-Management/All-States.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            s.Name = txtName.Text.ToUpper().Trim();
            s.created_at = DateTime.Now;
            bool isSuccess = s.Insert();
            if (isSuccess == true)
            {
                popup.Visible = true;
                message.InnerHtml = "State Successfully Added";
                Clear();
            }
            else
            {
                popupDanger.Visible = true;
                errMessage.InnerHtml = "State Fail To Add. <strong>" + s.Error + "</strong>";
            }
        }
    }

    #endregion BACK BUTTON CLICK EVENT

    #region CLEAR FIELDS

    public void Clear()
    {
        txtName.Text = "";
    }

    #endregion CLEAR FIELDS

    #region CUSTOM VALIDATION FOR CHECKING NAME IF EXISTS

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

    #endregion CUSTOM VALIDATION FOR CHECKING NAME IF EXISTS
}