using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
    {
    class PasswordForm
        {
        Boolean validation;
        String username = "DAP";
        String password = "123";

        static int height;
        static int width;
        static int headerHeight = 40;
        static int spacing = 20;
        static int widgetHeight = 30;
        static int widgetWidth = 70;
        static int margin = 50;

        public Boolean ShowDialog()
            {
            validation = false;

            // -------------------------------------------------------------------------------------------------
            // SET DIMENSIONS
            // -------------------------------------------------------------------------------------------------
            height = (widgetHeight * 4) + (spacing * 5) + headerHeight;
            width = (widgetWidth * 2) + spacing + (margin * 2) + 10;

            // -------------------------------------------------------------------------------------------------
            // INIT FORM
            // -------------------------------------------------------------------------------------------------
            Form form = new Form()
                {
                Width = width,
                Height = height,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "AUTHENTICATION",
                StartPosition = FormStartPosition.CenterScreen
                };

            // -------------------------------------------------------------------------------------------------
            // BUTTONS & CLICKS
            // -------------------------------------------------------------------------------------------------
            Label authenticationL = new Label() { Text = "ENTER CREDENTIALS", Left = margin, Top = spacing, Height = widgetHeight, Width = width - (margin * 2) };

            Label usernameL = new Label() { Text = "Username", Left = margin, Top = spacing * 2 + widgetHeight, Height = widgetHeight, Width = widgetWidth };
            TextBox usernameTB = new TextBox() { Left = margin + widgetWidth + spacing, Top = spacing * 2 + widgetHeight, Height = widgetHeight, Width = widgetWidth };
            usernameTB.KeyUp += (sender, e) => { if (e.KeyCode == Keys.Enter) form.SelectNextControl((Control)sender, true, true, true, true); };

            Label passwordL = new Label() { Text = "Password", Left = margin, Top = (spacing * 3) + (widgetHeight * 2), Height = widgetHeight, Width = widgetWidth };
            TextBox passwordTB = new TextBox() { Left = margin + widgetWidth + spacing, Top = (spacing * 3) + (widgetHeight * 2), Height = widgetHeight, Width = widgetWidth };
            passwordTB.KeyUp += (sender, e) => {
                if (e.KeyCode == Keys.Enter)
                    {
                    if (ValidatePassword(usernameTB.Text, passwordTB.Text))
                        {
                        validation = true;
                        form.Close();
                        }
                    else
                        validation = false;
                    }
            };

            Button cancel = new Button() {Text = "Cancel", Left = margin, Top = (spacing * 4) + (widgetHeight * 3), Height = widgetHeight, Width = widgetWidth };
            cancel.Click += (sender, e) => { form.Close(); };

            Button confirmation = new Button() { Text = "Enter", Left = margin + widgetWidth + spacing, Top = (spacing * 4) + (widgetHeight * 3), Height = widgetHeight, Width = widgetWidth };
            confirmation.Click += (sender, e) => {
                if (ValidatePassword(usernameTB.Text, passwordTB.Text))
                    {
                    validation = true;
                    form.Close();
                    }
                else
                    validation = false;
            };

            // -------------------------------------------------------------------------------------------------
            // ADD ITEMS TO FORM
            // -------------------------------------------------------------------------------------------------
            form.Controls.Add(authenticationL);
            form.Controls.Add(usernameL);
            form.Controls.Add(passwordL);
            form.Controls.Add(usernameTB);
            form.Controls.Add(passwordTB);
            form.Controls.Add(confirmation);
            form.Controls.Add(cancel);

            form.ShowDialog();

            return validation;
            }
        // -------------------------------------------------------------------------------------------------
        public Boolean ValidatePassword(String username, String password)
            {
            if(this.username.Equals(username) && this.password.Equals(password))
                {
                return true;
                }

            return false;
            }
        }
    }
