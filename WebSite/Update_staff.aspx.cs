using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class Update_staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else if (Session["account"].ToString() != "staff")
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string SqlString = "SELECT [user].*, staff.* FROM [user] INNER JOIN staff ON [user].userid = staff.userid WHERE [user].userid = @userid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)
                {
                    HiddenName.Value = dr["fname"].ToString() + " " + dr["lname"].ToString();
                    HiddenUserid.Value = dr["userid"].ToString();
                    HiddenUsername.Value = dr["username"].ToString();
                    HiddenPhone.Value = dr["phone"].ToString();
                    HiddenEmail.Value = dr["email"].ToString();
                    HiddenPicSrc.Value = dr["pic"].ToString();
                    txtResume.Text = dr["resume"].ToString();
                    txtZip.Text = dr["zip"].ToString();

                    if (dr["field"].ToString() == "")
                    {
                        DdField.SelectedIndex = 0;
                    }
                    else
                    {
                        DdField.SelectedValue = dr["field"].ToString();
                    }

                    if (dr["edu"].ToString() == "")
                    {
                        DdEdu.SelectedIndex = 0;
                    }
                    else
                    {
                        DdEdu.SelectedIndex = Int32.Parse(dr["edu"].ToString());
                    }

                    if (dr["exp"].ToString() == "")
                    {
                        DdExp.SelectedIndex = 0;
                    }
                    else
                    {
                        DdExp.SelectedValue = dr["exp"].ToString();
                    }

                    if (dr["sal"].ToString() == "")
                    {
                        DdSal.SelectedIndex = 0;
                    }
                    else
                    {
                        DdSal.SelectedIndex = Int32.Parse(dr["sal"].ToString());
                    }

                    if (dr["status"].ToString() == "1")
                    {
                        RadioStatus1.Checked = true;
                    }
                    else
                    {
                        RadioStatus0.Checked = true;
                    }

                }
                else
                {
                    dr.Close();
                    Session["userid"] = null;
                    Session["username"] = null;
                    Session["account"] = null;
                    Response.Redirect("~/Login.aspx");
                }
                dr.Close();
            }

            lblError.Text = "";
            lblUpload.Text = "";

            lblName.Text = HiddenName.Value;
            lblUserid.Text = HiddenUserid.Value;
            lblUsername.Text = HiddenUsername.Value;
            lblPhone.Text = HiddenPhone.Value;
            lblEmail.Text = HiddenEmail.Value;
            ImgPic.ImageUrl = HiddenPicSrc.Value;
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        string sSavePath = "~/images/user/";
        int intThumbWidth = 200;
        int intThumbHeight = 200;

        if (FileImg.PostedFile != null)
        {
            HttpPostedFile userImage = FileImg.PostedFile;
            int fileSize = userImage.ContentLength;

            if (fileSize == 0)
            {
                lblUpload.Text = "No file was uploaded";
                return;
            }

            string FileType = System.IO.Path.GetExtension(userImage.FileName).ToLower();
            if (FileType != ".jpg" && FileType != ".png" && FileType != ".gif" && FileType != ".bmp")
            {
                lblUpload.Text = "Only jpg, png, gif and bmp image files supported";
                return;
            }

            byte[] imageData = new Byte[fileSize];
            userImage.InputStream.Read(imageData, 0, fileSize);

            string sfileName = System.IO.Path.GetFileName(userImage.FileName);
            
            int file_append = 0;
            while (System.IO.File.Exists(Server.MapPath(sSavePath + sfileName)))
            {
                file_append++;
                sfileName = System.IO.Path.GetFileNameWithoutExtension(userImage.FileName) + file_append.ToString() + FileType;
            }

            System.IO.FileStream newImage = new System.IO.FileStream(Server.MapPath(sSavePath + sfileName), System.IO.FileMode.Create);
            newImage.Write(imageData, 0, imageData.Length);
            newImage.Close();
            

            System.Drawing.Image.GetThumbnailImageAbort myCallBack = new System.Drawing.Image.GetThumbnailImageAbort(this.ThumnailCallback);

            Bitmap myBitmap;
            try
            {
                myBitmap = new Bitmap(Server.MapPath(sSavePath + sfileName));

                file_append = 0;
                string ThumbFile = System.IO.Path.GetFileNameWithoutExtension(userImage.FileName) + FileType;

                while (System.IO.File.Exists(Server.MapPath(sSavePath + ThumbFile)))
                {
                    file_append++;
                    ThumbFile = System.IO.Path.GetFileNameWithoutExtension(userImage.FileName) + file_append.ToString() + FileType;
                }

                System.Drawing.Image newThumb = myBitmap.GetThumbnailImage(intThumbWidth, intThumbHeight, myCallBack, IntPtr.Zero);
                newThumb.Save (Server.MapPath(sSavePath + ThumbFile));
                

                

                string SqlString = "UPDATE [staff] SET pic = @pic WHERE userid = @userid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("pic", sSavePath + ThumbFile);
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                //cmd.ExecuteNonQuery();

                if (cmd.ExecuteNonQuery().Equals(1))
                {
                    if (HiddenPicSrc.Value != "~/images/user/Default.jpg" && System.IO.File.Exists(Server.MapPath(HiddenPicSrc.Value)))
                    {
                        System.IO.File.Delete(Server.MapPath(HiddenPicSrc.Value));
                    }
                    lblUpload.Text = "Image uploaded successfully";
                    ImgPic.ImageUrl = sSavePath + ThumbFile;
                    HiddenPicSrc.Value = sSavePath + ThumbFile;
                    
                }
                else // If user was not able to be saved to database
                {
                    lblUpload.Text = "There was an error, Please try again.";
                }

                
                newThumb.Dispose();
                myBitmap.Dispose();

            }
            catch (ArgumentException errArgument)
            {
                lblUpload.Text = "The file wasn't a valid image file.";
            }

            System.IO.File.Delete(Server.MapPath(sSavePath + sfileName));
            
        }
    }

    public bool ThumnailCallback()
    {
        return false;
    }

    protected void FieldValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DdField.SelectedIndex == 0)
        {
            args.IsValid = false;
        }
    }
    protected void EduValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DdEdu.SelectedIndex == 0)
        {
            args.IsValid = false;
        }
    }
    protected void ExpValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DdExp.SelectedIndex == 0)
        {
            args.IsValid = false;
        }
    }
    protected void SalValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DdSal.SelectedIndex == 0)
        {
            args.IsValid = false;
        }
    }
    protected void ZipValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!this.IsZipCode(txtZip.Text))
        {
            args.IsValid = false;
        }
    }

    public bool IsZipCode(string zipCode)
    {
        string pattern = @"^\d{5}(\-\d{4})?$";
        Regex regex = new Regex(pattern);
 
        return regex.IsMatch(zipCode);
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int status = 0;
            if (RadioStatus1.Checked)
            {
                status = 1;
            }

            string SqlString = "UPDATE [staff] SET zip = @zip, field = @field, exp = @exp, edu = @edu, sal = @sal, resume = @resume, status = @status WHERE userid = @userid";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("zip", txtZip.Text);
            cmd.Parameters.AddWithValue("field", DdField.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("exp", Int32.Parse(DdExp.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("edu", Int32.Parse(DdEdu.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("sal", Int32.Parse(DdSal.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("resume", txtResume.Text);
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
            cmd.Connection.Open();
            //cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery().Equals(1))
            {
                lblError.Text = "Update was successful.";
            }
            else // If user was not able to be saved to database
            {
                lblError.Text = "There was an error, Please try again.";
            }
        }
    }

}