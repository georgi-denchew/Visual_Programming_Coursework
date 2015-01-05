
namespace Desktop.Forms.Common
{
    using OrdersSystem.Data;
    using System.Windows.Forms;


    public partial class BaseForm : Form
    {
        protected const string RequiredFieldMessage = "This field is required!";

        protected OrdersEntities Data;

        public BaseForm()
        {
            InitializeComponent();
            Data = new OrdersEntities();
        }

        protected void ShowMessage(string caption, string message)
        {
            var buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        protected bool ValidateRequiredInputField(ErrorProvider error, string errorMessage, TextBox inputField)
        {
            bool isValidInput = false;

            if (string.IsNullOrEmpty(inputField.Text.Trim()))
            {
                error.SetError(inputField, errorMessage);
            }
            else
            {
                error.Clear();
                isValidInput = true;
            }

            return isValidInput;
        }
    }
}
