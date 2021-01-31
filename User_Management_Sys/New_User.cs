using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;



//Data Source=DESKTOP-P1VKNUD\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True

namespace User_Management_Sys
{
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-P1VKNUD\\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True");

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Users (UserName, DisplayName, Phone, Email, UserRoles, Enabled) values('" + txtUserName.Text + "','" + txtDisplayName.Text + "','" + txtPhone.Text + "','" + txtEmail.Text + "','" + cmbBoxUserRole.Text + "','" + checkEnabled.Checked + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            

            User_Management_Screen user_Management = new User_Management_Screen();
            user_Management.Show();
            this.Hide();

        }

        private void checkEnabled_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
