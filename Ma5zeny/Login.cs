using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Ma5zeny
{
    public partial class Login : MaterialForm
    {
        public Login()
        { 
         
            InitializeComponent();

         
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string username = passText.Text;
            string password = userText.Text;
            bool success = false;


                foreach (var Manager in AppManager.entities.Mangers)
            {
                if (username == Manager.Usename)
                {
                    success = Manager.Password == password ? true : false;
                    AppManager.CurrentManager = Manager;
                }
            }
            if (success)
            {             
                    AppManager.DashboardForm.Show();
                    AppManager.LoginForm.Hide();
            }
            else
            {
                MessageBox.Show("incorrect credintials");
            }
        }
    }
}
