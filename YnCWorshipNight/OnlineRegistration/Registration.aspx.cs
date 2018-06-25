using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using MySql.Data.MySqlClient;

namespace OnlineRegistration
{
    public partial class Registration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                //string MyConnection2 = "datasource=localhost;username=root;password=root";
                string MyConnection2 = "datasource=localhost;username=root";
                //This is my insert query in which i am taking input from the user through windows forms  
                //string Query = "insert into student.studentinfo(idStudentInfo,Name,Father_Name,Age,Semester) values('" + this.IdTextBox.Text + "','" + this.NameTextBox.Text + "','" + this.FnameTextBox.Text + "','" + this.AgeTextBox.Text + "','" + this.SemesterTextBox.Text + "');";
                //string Query = "insert into ync_db.registration(ID,TicketNumber,FullName,MobilePhone,Email) values('2','ABC456','" + Fullname.Text + "','" + this.AgeTextBox.Text + "','" + this.SemesterTextBox.Text + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                //MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                //MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                //MessageBox.Show("Save Data");
                //while (MyReader2.Read())
                //{
                //}
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }  
    }
}