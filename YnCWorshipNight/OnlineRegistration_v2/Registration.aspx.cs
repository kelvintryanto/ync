﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Net;
using System.Net.Mail;
using System.IO; 

namespace OnlineRegistration_v2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            String gender = "";
            String asalparoki = "";
            var TicketNumber = GenerateTicketNumber(8);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + TicketNumber + "')", true);

            if (ddlGender.SelectedValue == "0")
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
                
            if (ddlAsalParoki.SelectedValue == "0")
            {
                asalparoki = "Santa Monika";
            }
            else
            {
                asalparoki = "Bukan Santa Monika";
            }

            try
            {
                Int32 returnvalue = doInsertRegis(TicketNumber, txtFullname.Text, Convert.ToDateTime(txtDOB.Text), txtMobilePhone.Text, txtEmailAddress.Text, txtHomeAddress.Text, txtLineID.Text, gender, asalparoki);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Register SUCCESS !')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Register FAILED !')", true);
            }

            #region send_email

            //Fetching Settings from WEB.CONFIG file.  
            string emailSender = ConfigurationManager.AppSettings["emailsender"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["smtpserver"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);

            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = "D:\\YnC\\YnCWorshipNight\\OnlineRegistration_v2\\EmailTemplates\\EmailInvitation.html";
            //string FilePath = "D:\\Others\\YnC Project\\YnCWorshipNight - Copy\\OnlineRegistration_v2\\EmailTemplates\\EmailInvitation.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Repalce [newusername] = signup user name   
            MailText = MailText.Replace("[FullName]", txtFullname.Text.Trim());
            MailText = MailText.Replace("[TicketNumber]", TicketNumber.Trim());

            string subject = "YnC Worship Night - Registration Success!!";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(txtEmailAddress.Text.ToString());

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = MailText;

            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);  

            #endregion


            //string connetionString = null;
            //SqlConnection cnn ;
            //connetionString = "Data Source=localhost;Initial Catalog=YnCDB;User ID=sa;Password=Password*7";
            //cnn = new SqlConnection(connetionString);
            //try
            //{
            //    cnn.Open();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Connection Open !')", true);
            //    //MessageBox.Show ("Connection Open ! ");
            //    cnn.Close();
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can not open connection !')", true);
            //    //MessageBox.Show("Can not open connection ! ");
            //}
        }

        //private static Random random = new Random();
        public static string GenerateTicketNumber(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region Private Function

        private static String ConnString(String _name)
        {
            return ConfigurationManager.ConnectionStrings[_name].ToString();
        }

        private static Int32 doInsertRegis(String _ticketnumber, String _fullname, DateTime _dob, String _mobilephone, String _email, String _homeaddress, String _lineid, String _gender, String _asalparoki)
        {
            SqlConnection conn = new SqlConnection(ConnString("YnCDB_Connection"));
            SqlCommand cmd = new SqlCommand("usp_Registration_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNumber", _ticketnumber);
            cmd.Parameters.AddWithValue("@FullName", _fullname);
            cmd.Parameters.AddWithValue("@DateOfBirth", _dob);
            cmd.Parameters.AddWithValue("@MobilePhone", _mobilephone);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@HomeAddress", _homeaddress);
            cmd.Parameters.AddWithValue("@LineID", _lineid);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@AsalParoki", _asalparoki);

            SqlParameter returnparameter = new SqlParameter("@returnvalue", SqlDbType.Int);
            returnparameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnparameter);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Int32 returnvalue = (Int32)returnparameter.Value;

            return returnvalue;
        }

        #endregion

    }
}