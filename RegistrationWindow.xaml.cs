using StoreWithDataSources.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataSources
{
    /// <summary>
    /// Interaction logic for SimpleWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        GetData data = new GetData();
        Check check = new Check();
        private string password = "";
        private string passwordHash = "";
        private string confirmPassword = "";
        private string confirmPasswordHash = "";

        public bool RememberMeIsChecked { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void TxtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
            {
                cbEyePassword.Visibility = Visibility.Visible;
                password = txtPassword.Password;
            }   
            else cbEyePassword.Visibility = Visibility.Hidden;

            if (txtConfirmPassword.Password.Length > 0)
            {
                cbEyeConfirmPassword.Visibility = Visibility.Visible;
                confirmPassword = txtConfirmPassword.Password;
            }   
            else cbEyeConfirmPassword.Visibility = Visibility.Hidden;
        }

        void ShowPassword()
        {
            if (cbEyePassword.IsFocused)
            {
                txtVisiblePassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Hidden;
                txtVisiblePassword.Text = txtPassword.Password;
                password = txtVisiblePassword.Text;
            }
            if (cbEyeConfirmPassword.IsFocused)
            {
                txtVisibleConfirmPassword.Visibility = Visibility.Visible;
                txtConfirmPassword.Visibility = Visibility.Hidden;
                txtVisibleConfirmPassword.Text = txtConfirmPassword.Password;
                confirmPassword = txtVisibleConfirmPassword.Text;
            }
        }
        void HidePassword()
        {
            if (cbEyePassword.IsFocused)
            {
                txtVisiblePassword.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Password = txtVisiblePassword.Text;
                txtPassword.Focus();
            }
            if (cbEyeConfirmPassword.IsFocused)
            {
                txtVisibleConfirmPassword.Visibility = Visibility.Hidden;
                txtConfirmPassword.Visibility = Visibility.Visible;
                txtConfirmPassword.Password = txtVisibleConfirmPassword.Text;
                txtVisibleConfirmPassword.Focus();
            }
        }

        private void cbEye_Checked(object sender, RoutedEventArgs e)
        {
            ShowPassword();
        }

        private void cbEye_Unchecked(object sender, RoutedEventArgs e)
        {
            HidePassword();
        }

        private void Registration_Handler(object sender, RoutedEventArgs e)
        {
            if (!check.CheckValidationUserName(tbUserName.Text))
            {
                MessageBox.Show("Username must be " +
                                "\nat least 8 characters",
                                "Require",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!check.CheckValidationPassword(password))
            {
                MessageBox.Show("Password must be at least " +
                                "\ncontain 8 characters, " +
                                "\nat least one small one," +
                                "\none capital," +
                                "\nand one digit", "Require",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string userName = "";
            GetData getData = new GetData();
            HashEncryption hashEncryption = new HashEncryption();
            
            userName = tbUserName.Text;
            passwordHash = hashEncryption.GetHashPassword(password);
            confirmPasswordHash = hashEncryption.GetHashPassword(confirmPassword);

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords dont equal", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                password = "";
                confirmPassword = "";
                return;
            }

            if (check.CheckUser(userName, password))
            {
                return;
            }

            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Users(UserName, Password) VALUES('{userName}', '{passwordHash}')", getData.GetSqlConnection());

            
            try
            {
                getData.OpenConnection();
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    if (RememberMeIsChecked)
                    {
                        StoreWithDataSources.Properties.Settings.Default.UserName = userName;
                        StoreWithDataSources.Properties.Settings.Default.Password = password;
                        StoreWithDataSources.Properties.Settings.Default.Save();
                    }
                    
                    MessageBox.Show("You are registered", "Succsess", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                getData.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Load_RegistrationWindow(object sender, RoutedEventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private void LogIn_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            App.mainWindow.Show();
        }

        private void chbRememberMe_Checked(object sender, RoutedEventArgs e)
        {
            RememberMeIsChecked = true;
        }

        private void chbRememberMe_Unchecked(object sender, RoutedEventArgs e)
        {
            RememberMeIsChecked = false;
        }

        private void txtVisiblePassword_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            password = txtVisiblePassword.Text;
            txtPassword.Password = txtVisiblePassword.Text;
        }

        private void txtVisibleConfirmPassword_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            confirmPassword = txtVisibleConfirmPassword.Text;
            txtConfirmPassword.Password = txtVisibleConfirmPassword.Text;
        }
    }
}
