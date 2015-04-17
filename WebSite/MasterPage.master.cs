using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Update_Btn_Visibility();
    }

    // Used to show/hide buttons based on user session
    protected void Update_Btn_Visibility()
    {
        if (Session["account"] == null) // If user logged in
        {
            // Hide
            BtnAcct.Visible = false;
            BtnLogout.Visible = false;
            BtnSearch.Visible = false;
            BtnClient.Visible = false;
            BtnContract.Visible = false;
            BtnRequests.Visible = false;
            BtnStaff.Visible = false;

            // Show
            BtnReg.Visible = true;
            BtnLogin.Visible = true;

        }
        else // If user logged out
        {
            // Show
            BtnAcct.Visible = true;
            BtnLogout.Visible = true;
            BtnSearch.Visible = true;

            // Hide
            BtnReg.Visible = false;
            BtnLogin.Visible = false;

            string acctType = Session["account"].ToString();

            if (acctType == "manager") // If user is manager
            {
                BtnClient.Visible = false;
                BtnContract.Visible = true;
                BtnRequests.Visible = true;
                BtnStaff.Visible = false;
            }
            else if (acctType == "client") // if user is client
            {
                BtnClient.Visible = true;
                BtnContract.Visible = true;
                BtnRequests.Visible = false;
                BtnStaff.Visible = false;
            }
            else if (acctType == "staff") // if user is staff
            {
                BtnClient.Visible = false;
                BtnContract.Visible = false;
                BtnRequests.Visible = true;
                BtnStaff.Visible = true;
            }
            else
            {
                BtnClient.Visible = false;
                BtnContract.Visible = false;
                BtnRequests.Visible = false;
                BtnStaff.Visible = false;
            }
        }
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session["account"] = null;
        Session["userid"] = null;
        Session["username"] = null;
        Response.Redirect("~/Default.aspx");
    }

}
