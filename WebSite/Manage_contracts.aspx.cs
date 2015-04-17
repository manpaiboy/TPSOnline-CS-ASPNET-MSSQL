using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Manage_contracts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnNewContract.Visible = false;
        // Check if user has proper permission for this area
        if (Session["account"] != null && (Session["account"].ToString() == "manager" || Session["account"].ToString() == "client"))
        {
            string SqlString = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string SqlString2 = "";
            SqlCommand cmd2 = null;
            SqlDataReader dr2 = null;

            // Open connections to db
            if (Session["account"].ToString() == "client") // if client
            {
                BtnNewContract.Visible = true;
                SqlString = "SELECT [contract].*, [client].company FROM [contract]"
                    + " INNER JOIN [client] ON [contract].userid = [client].userid"
                    + " WHERE [contract].userid = @userid"
                    + " ORDER BY [contract].status ASC, [contract].contractid DESC";
                cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else // if manager
            {
                SqlString = "SELECT * FROM [contract]"
                    + " INNER JOIN client ON [contract].userid = client.userid"
                    + " WHERE status <> 2"
                    + " ORDER BY status ASC, contractid DESC";
                cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Connection.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            string rowcolor = "r0";
            int counter = 0;

            while (dr.Read()) // while there are rows to read in the db
            {
                if (counter == 0) // if this is the first row add titles to the table
                {
                    TableRow hr = new TableRow();
                    hr.CssClass = "ctitle";

                    TableCell h0 = new TableCell();
                    h0.Controls.Add(new LiteralControl("Contract (ID)"));
                    hr.Cells.Add(h0);

                    TableCell h1 = new TableCell();
                    h1.Controls.Add(new LiteralControl("Position"));
                    hr.Cells.Add(h1);

                    TableCell h2 = new TableCell();
                    h2.Controls.Add(new LiteralControl("Company"));
                    hr.Cells.Add(h2);

                    TableCell h3 = new TableCell();
                    h3.Controls.Add(new LiteralControl("Salary Range"));
                    hr.Cells.Add(h3);

                    TableCell h4 = new TableCell();
                    h4.Controls.Add(new LiteralControl("Location"));
                    hr.Cells.Add(h4);

                    TableCell h5 = new TableCell();
                    h5.Controls.Add(new LiteralControl("Status"));
                    hr.Cells.Add(h5);

                    // Buttons - No Title just an empty cell
                    // Manager - Find, Staff, Set valid/Invalid, Remove
                    // Client - Find Staff, Set Unable to fill, Remove
                    
                    TableCell h6 = new TableCell(); // Find Staff Buttons
                    h6.Controls.Add(new LiteralControl("&nbsp;"));
                    hr.Cells.Add(h6);

                    TableCell h7 = new TableCell(); // Modify Status Buttons
                    h7.Controls.Add(new LiteralControl("&nbsp;"));
                    hr.Cells.Add(h7);

                    TableCell h8 = new TableCell(); // Delete from DB Buttons
                    h8.Controls.Add(new LiteralControl("&nbsp;"));
                    hr.Cells.Add(h8);

                    tblContracts.Rows.Add(hr);
                }

                // Temporarily store requested row data
                int contractid = Int32.Parse(dr["contractid"].ToString());
                string cname = dr["cname"].ToString();
                string company = dr["company"].ToString();
                string position = dr["field"].ToString();
                int zip = Int32.Parse(dr["zip"].ToString());

                string statusStr = "";
                int status = Int32.Parse(dr["status"].ToString());
                if (status == 0) // invalid
                {
                    statusStr = "Invalid";
                }
                else if (status == 1) // valid
                {
                    statusStr = "Valid";
                }
                else if (status == 2) // filled
                {
                    statusStr = "Filled";
                }
                else // unable to fill (3)
                {
                    statusStr = "Unable to Fill";
                }

                string salary = "";
                int sal = Int32.Parse(dr["sal"].ToString());

                if (sal == 1)
                {
                    salary = "$10,000+";
                }
                else if (sal == 2)
                {
                    salary = "$20,000+";
                }
                else if (sal == 3)
                {
                    salary = "$30,000+";
                }
                else if (sal == 4)
                {
                    salary = "$40,000+";
                }
                else if (sal == 5)
                {
                    salary = "$50,000+";
                }
                else if (sal == 6)
                {
                    salary = "$60,000+";
                }
                else if (sal == 7)
                {
                    salary = "$70,000+";
                }
                else if (sal == 8)
                {
                    salary = "$80,000+";
                }
                else if (sal == 9)
                {
                    salary = "$90,000+";
                }
                else if (sal == 10)
                {
                    salary = "$100,000+";
                }
                else if (sal == 11)
                {
                    salary = "$110,000+";
                }
                else if (sal == 12)
                {
                    salary = "$120,000+";
                }
                else if (sal == 13)
                {
                    salary = "$130,000+";
                }
                else if (sal == 14)
                {
                    salary = "$140,000+";
                }
                else if (sal == 15)
                {
                    salary = "$150,000+";
                }
                else
                {
                    salary = "Unspecified";
                }

                // Create a new table row
                TableRow r = new TableRow();
                r.CssClass = rowcolor;

                // Add cells to the new table row
                TableCell c0 = new TableCell();
                c0.Controls.Add(new LiteralControl("<a href='View_Contract.aspx?id=" + contractid.ToString() + "'>" + cname + " (#" + contractid.ToString() + ")</a>"));
                r.Cells.Add(c0);
                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl(position));
                r.Cells.Add(c1);
                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(company));
                r.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Controls.Add(new LiteralControl(salary));
                r.Cells.Add(c3);
                TableCell c4 = new TableCell();
                c4.Controls.Add(new LiteralControl(zip.ToString()));
                r.Cells.Add(c4);
                TableCell c5 = new TableCell();
                c5.Controls.Add(new LiteralControl(statusStr));
                r.Cells.Add(c5);

                // Add Buttons to table row
                TableCell c6 = new TableCell();
                TableCell c7 = new TableCell();
                TableCell c8 = new TableCell();

                Button Btn01 = new Button();
                Btn01.ID = "Btn01" + counter.ToString();
                Btn01.CssClass = "btn-sm btn-primary";
                Btn01.PostBackUrl = "~/Find_staff.aspx?id=" + contractid.ToString();
                //Btn01.CommandArgument = contractid.ToString();
                Btn01.Text = "Find Staff";
                //Btn01.Click += new System.EventHandler(this.BtnFindStaff_Click);

                Button Btn02 = new Button();
                Btn02.ID = "Btn02" + counter.ToString();
                Btn02.CssClass = "btn-sm btn-primary";
                Btn02.CommandArgument = contractid.ToString();

                if (Session["account"].ToString() == "client")
                {
                    Btn02.Text = "Unable to Fill";
                    Btn02.Click += new System.EventHandler(this.BtnUnableToFill_Click);
                }
                else // manager
                {
                    if (status == 1)
                    {                        
                        Btn02.Text = "Set as Invalid";
                        Btn02.Click += new System.EventHandler(this.BtnSetInvalid_Click);
                    }
                    else
                    {
                        Btn02.Text = "Set as Valid";
                        Btn02.Click += new System.EventHandler(this.BtnSetValid_Click);
                    }
                }

                Button Btn03 = new Button();
                Btn03.ID = "Btn03" + counter.ToString();
                Btn03.CssClass = "btn-sm btn-primary";
                Btn03.CommandArgument = contractid.ToString();
                Btn03.Text = "Remove";
                Btn03.Click += new System.EventHandler(this.BtnRemoveContract_Click);

                c6.Controls.Add(Btn01);
                r.Cells.Add(c6);
                c7.Controls.Add(Btn02);
                r.Cells.Add(c7);
                c8.Controls.Add(Btn03);
                r.Cells.Add(c8);

                // insert new row into table
                tblContracts.Rows.Add(r);

                // Check for any requests associated with this contract
                SqlString2 = "SELECT [request].*, [user].fname, [user].lname FROM [request]"
                    + " INNER JOIN [user] ON [request].userid = [user].userid"
                    + " WHERE contractid = @contractid"
                    + " ORDER BY approval ASC, requestid DESC";
                cmd2 = new SqlCommand(SqlString2, new SqlConnection(GetConnectionString()));
                cmd2.Parameters.AddWithValue("contractid", contractid.ToString());
                cmd2.Connection.Open();
                dr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);

                // Display request status
                while (dr2.Read())
                {
                    // store request data
                    int requestid = Int32.Parse(dr2["requestid"].ToString());
                    int staffid = Int32.Parse(dr2["userid"].ToString());
                    string staffname = dr2["fname"].ToString() + " " + dr2["lname"].ToString();
                    
                    string approvalStr = "";
                    int rapproval = Int32.Parse(dr2["approval"].ToString());

                    if (rapproval == 0) // Pending approval from manager
                    {
                        approvalStr = "Pending";
                    }
                    else if (rapproval == 1) // Request has been approved by manager and pending acceptence from staff
                    {
                        approvalStr = "Pending";
                    }
                    else if (rapproval == 2) // Request has been filled/accepted
                    {
                        approvalStr = "Accepted";
                    }

                    // Add a new row for request data
                    TableRow rr = new TableRow();
                   
                    // Add cells to the new request row
                    TableCell rc0 = new TableCell();
                    rc0.Controls.Add(new LiteralControl("<a href='View_Staff.aspx?id=" + staffid.ToString() + "'>" + staffname + " (#" + staffid.ToString() + ")</a>"));
                    rr.Cells.Add(rc0);

                    TableCell rc1 = new TableCell();
                    rc1.Controls.Add(new LiteralControl("Request # " + requestid.ToString()));
                    rr.Cells.Add(rc1);

                    TableCell rc2 = new TableCell();
                    rc2.Controls.Add(new LiteralControl("&nbsp;"));
                    rr.Cells.Add(rc2);
                    TableCell rc3 = new TableCell();
                    rc3.Controls.Add(new LiteralControl("&nbsp;"));
                    rr.Cells.Add(rc3);
                    TableCell rc4 = new TableCell();
                    rc4.Controls.Add(new LiteralControl("&nbsp;"));
                    rr.Cells.Add(rc4);

                    TableCell rc5 = new TableCell();
                    rc5.Controls.Add(new LiteralControl(approvalStr));
                    rr.Cells.Add(rc5);

                    if (rapproval != 2) // If request has not been accepted allow client to cancel request
                    {
                        TableCell rc6 = new TableCell();

                        Button Btn04 = new Button();
                        Btn04.ID = "Btn04" + counter.ToString();
                        Btn04.CssClass = "btn-sm btn-primary";
                        Btn04.CommandArgument = requestid.ToString();
                        Btn04.Text = "Cancel";
                        Btn04.Click += new System.EventHandler(this.BtnCancelRequest_Click);

                        rc6.Controls.Add(Btn04);
                        rr.Cells.Add(rc6);
                    }

                    // insert new row into table
                    tblContracts.Rows.Add(rr);

                    counter++;
                }
                // close 2nd connection
                dr2.Close();
                dr2.Dispose();
                cmd2.Connection.Close();
                cmd2.Connection.Dispose();

                // Modify counter/rowcolor data for next row
                counter++;

                // Commented out so row color is always the same
                /*if (rowcolor == "r0")
                {
                    rowcolor = "r1";
                }
                else
                {
                    rowcolor = "r0";
                }*/

            }
            // Close connections to db            
            dr.Close();
            dr.Dispose();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
        else // if user should not have access to the area redirect to homepage
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

    protected void BtnCancelRequest_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;
        int requestid = Int32.Parse(Btn.CommandArgument.ToString());

        string SqlString = "DELETE FROM [request] WHERE requestid = @requestid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("requestid", requestid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/Manage_contracts.aspx");
    }

    protected void BtnSetValid_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;
        int contractid = Int32.Parse(Btn.CommandArgument.ToString());

        string SqlString = "UPDATE [contract] SET status = 1 WHERE contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("contractid", contractid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/Manage_contracts.aspx");
    }

    protected void BtnSetInvalid_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;
        int contractid = Int32.Parse(Btn.CommandArgument.ToString());

        string SqlString = "UPDATE [contract] SET status = 0 WHERE contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("contractid", contractid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/Manage_contracts.aspx");
    }

    protected void BtnUnableToFill_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;
        int contractid = Int32.Parse(Btn.CommandArgument.ToString());

        string SqlString = "UPDATE [contract] SET status = 3 WHERE contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("contractid", contractid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/Manage_contracts.aspx");
    }

    protected void BtnRemoveContract_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;
        int contractid = Int32.Parse(Btn.CommandArgument.ToString());

        // Remove any requests associated with this contract
        string SqlString = "DELETE FROM [request] WHERE contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("contractid", contractid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();

        // Remove the actual contract
        SqlString = "DELETE FROM [contract] WHERE contractid = @contractid";
        cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("contractid", contractid.ToString());
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();

        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/Manage_contracts.aspx");

    }

   /* protected void BtnFindStaff_Click(object sender, EventArgs e)
    {

    }*/

   /* protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Get values from the data entry fields in session state
        string businessName = txtCname.Text.Trim();
        string contractID = txtContractid.Text.Trim();
        string staffid = txtUserid.Text.Trim();

        // Remove the previous yellow
        txtCname.BackColor = System.Drawing.Color.White;
        txtContractid.BackColor = System.Drawing.Color.White;
        txtUserid.BackColor = System.Drawing.Color.White;

        //Add validation codes for CompanyName, Contract ID, Staff ID and Contract Date -- Checks for empty or filled with spaces
        if (string.IsNullOrEmpty(businessName) && string.IsNullOrEmpty(contractID) && string.IsNullOrEmpty(staffid))
        {
            txtContractid.BackColor = System.Drawing.Color.Yellow;
            txtCname.BackColor = System.Drawing.Color.Yellow;
            txtUserid.BackColor = System.Drawing.Color.Yellow;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Company Name may not be empty. Contract Number may not be empty. Staff ID may not be empty";
            return;
        }

        if (string.IsNullOrEmpty(businessName))
        {
            txtCname.BackColor = System.Drawing.Color.Yellow;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Company Name may not be empty.";
            return;
        }

        if (string.IsNullOrEmpty(contractID))
        {
            txtContractid.BackColor = System.Drawing.Color.Yellow;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Contract Number may not be empty.";
            return;
        }
         if (string.IsNullOrEmpty(staffid))
        {
            txtUserid.BackColor = System.Drawing.Color.Yellow;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Staff ID may not be empty.";
            return;
        }
    }*/
}
