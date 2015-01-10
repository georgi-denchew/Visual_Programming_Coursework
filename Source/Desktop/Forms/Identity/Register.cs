using Desktop.Forms.Common;
using OrdersSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Identity
{
    public partial class Register : BaseForm
    {
        private const string ExistingUserMessage = "Username already exists!";
        private const string PasswordMissmatchMessage = "Passwords don't match!";

        public ErrorProvider usernameErrorProvider { get; set; }
        public ErrorProvider passwordErrorProvider { get; set; }
        public ErrorProvider confirmPasswordErrorProvider { get; set; }
        public ErrorProvider firstNameErrorProvider { get; set; }
        public ErrorProvider lastNameErrorProvider { get; set; }

        public Register()
        {
            this.usernameErrorProvider = new ErrorProvider();
            this.passwordErrorProvider = new ErrorProvider();
            this.confirmPasswordErrorProvider = new ErrorProvider();
            this.firstNameErrorProvider = new ErrorProvider();
            this.lastNameErrorProvider = new ErrorProvider();
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.usernameErrorProvider.Clear();
            this.passwordErrorProvider.Clear();
            this.confirmPasswordErrorProvider.Clear();
            this.firstNameErrorProvider.Clear();
            this.lastNameErrorProvider.Clear();

            bool hasErrors = true;

            bool usernameError = !base.ValidateRequiredInputField(usernameErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxUsername);
            bool passwordError = !base.ValidateRequiredInputField(passwordErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxPassword);
            bool confirmPasswordError = !base.ValidateRequiredInputField(confirmPasswordErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxConfirmPassword);
            bool firstNameError = !base.ValidateRequiredInputField(firstNameErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxFirstName);
            bool lastNameError = !base.ValidateRequiredInputField(lastNameErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxLastName);

            hasErrors = usernameError || passwordError || confirmPasswordError || firstNameError || lastNameError;

            string username = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;
            string confirmPassword = this.textBoxConfirmPassword.Text;
            string firstName = this.textBoxFirstName.Text;
            string lastName = this.textBoxLastName.Text;

            var existingUser = base.Data.Users.FirstOrDefault(x => x.Username.Equals(username));


            if (existingUser != null)
            {
                usernameErrorProvider.SetError(this.textBoxUsername, ExistingUserMessage);
                hasErrors = true;
            }

            if (!password.Equals(confirmPassword))
            {
                confirmPasswordErrorProvider.SetError(this.textBoxConfirmPassword, PasswordMissmatchMessage);
                hasErrors = true;
            }

            if (!hasErrors)
            {
                //User newUser = new User()
                //{
                //    FirstName = firstName,
                //    LastName = lastName,
                //    Password = password,
                //    Username = username,
                //    ModificationDate = DateTime.Now
                //};

                //base.Data.Users.Add(newUser);
                base.Data.insertUser(username, password, firstName, lastName);
                base.Data.SaveChanges();

                LoginForm loginForm = new LoginForm();
                loginForm.MdiParent = this.MdiParent;
                loginForm.TextBoxUsername.Text = username;
                this.Hide();
                loginForm.Show();
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this.MdiParent;
            this.Hide();
            loginForm.Show();
            this.Close();
        }
    }
}
