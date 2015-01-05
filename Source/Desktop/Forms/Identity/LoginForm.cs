using Desktop.Forms.Common;
using Desktop.Forms.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class LoginForm : BaseForm
    {
        private const string InvalidUser = "Invalid Username or Password! Please try again.";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;

            var user = Data.Users.FirstOrDefault(x =>
                x.Username.Equals(username) &&
                x.Password.Equals(password));

            if (user == null)
            {
                MessageBox.Show(InvalidUser, "Invalid User",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                new ErrorProvider().SetError(this.buttonLogin, InvalidUser);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register();

            registerForm.MdiParent = this.MdiParent;
            this.Hide();
            registerForm.Show();
            this.Close();
        }
    }
}
