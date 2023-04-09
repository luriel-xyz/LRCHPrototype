using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRCHPrototype
{
    public partial class frmLogin : Form
    {


        public frmLogin()
        {

            InitializeComponent();

        }



        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }


        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void buttonSubmit_Click_1(object sender, EventArgs e)
        {
            if (textUser.Text == "admin1" && textPassword.Text == "12345678")
            {
                this.Visible = false;
                MainMenu mainScreen = new MainMenu();
                mainScreen.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: 'Username or password wrong.");
            }
           
        }


        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            textUser.Text = "";
            textPassword.Text = "";

        }
    }

}

