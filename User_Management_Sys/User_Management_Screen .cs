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

namespace User_Management_Sys
{
    public partial class User_Management_Screen : Form
    {
        public User_Management_Screen()
        {
            InitializeComponent();
            FullScreenData();

        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-P1VKNU\\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True");

        private void FullScreenData()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select ID, UserName, Email, Enabled from Users", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = reader["ID"].ToString();
                add.SubItems.Add(reader["UserName"].ToString());
                add.SubItems.Add(reader["Email"].ToString());
                add.SubItems.Add(reader["Enabled"].ToString());

                listView1.Items.Add(add);
            }
            connection.Close();
        }
        private void EnabledUser()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select ID, UserName, Email, Enabled from Users Where Enabled='True'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = reader["ID"].ToString();
                add.SubItems.Add(reader["UserName"].ToString());
                add.SubItems.Add(reader["Email"].ToString());
                add.SubItems.Add(reader["Enabled"].ToString());

                listView1.Items.Add(add);
            }
            connection.Close();
        }
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            New_User new_User = new New_User();
            new_User.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                listView1.Items.Clear();
                EnabledUser();
                
            }
            else
            {
                listView1.Items.Clear();
                FullScreenData();
            }
        }
    }
}
