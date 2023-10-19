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
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void TxtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
                cbEyePassword.Visibility = Visibility.Visible;
            else
                cbEyePassword.Visibility = Visibility.Hidden;
            if (txtConfirmPassword.Password.Length > 0)
                cbEyeConfirmPassword.Visibility = Visibility.Visible;
            else cbEyeConfirmPassword.Visibility = Visibility.Hidden;
        }

        void ShowPassword()
        {
            if (cbEyePassword.IsFocused)
            {
                txtVisiblePassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Hidden;
                txtVisiblePassword.Text = txtPassword.Password;
            }
            if (cbEyeConfirmPassword.IsFocused)
            {
                txtVisibleConfirmPassword.Visibility = Visibility.Visible;
                txtConfirmPassword.Visibility = Visibility.Hidden;
                txtVisibleConfirmPassword.Text = txtConfirmPassword.Password;
            }

        }
        void HidePassword()
        {
            if (cbEyePassword.IsFocused)
            {
                txtVisiblePassword.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Focus();
            }
            if (cbEyeConfirmPassword.IsFocused)
            {
                txtVisibleConfirmPassword.Visibility = Visibility.Hidden;
                txtConfirmPassword.Visibility = Visibility.Visible;
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
            GetData getData = new GetData();
            HashEncryption hashEncryption = new HashEncryption();
            Check check = new Check();

            string userName = tbUserName.Text;
            string password = hashEncryption.GetHashPassword(txtPassword.Password);
            string confirmPassword = hashEncryption.GetHashPassword(txtConfirmPassword.Password);


            if (check.CheckUser(userName, password))
            {
                return;
            }

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords dont equal", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Users(UserName, Password) VALUES('{userName}', '{password}')", getData.GetSqlConnection());

            getData.OpenConnection();
            try
            {
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    if (chbRememberMe.IsChecked)
                    {
                        StoreWithDataSources.Properties.Settings.Default.UserName = userName;
                        StoreWithDataSources.Properties.Settings.Default.Password = password;
                        StoreWithDataSources.Properties.Settings.Default.Save();
                    }
                    
                    MessageBox.Show("You are registered", "Succsess", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            getData.CloseConnection();
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
    }
}
