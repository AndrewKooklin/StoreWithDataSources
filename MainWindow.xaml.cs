using StoreWithDataSources.Data;
using System.Windows;

namespace StoreWithDataSources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Check check = new Check();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Handler(object sender, RoutedEventArgs e)
        {
            if (check.CheckUser(tbUserName.Text, txtPassword.Password))
            {
                this.Hide();
                WorkWindow workWindow = new WorkWindow();
                workWindow.Show();
                MessageBox.Show("You have successfully log in", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
                cbEyePassword.Visibility = Visibility.Visible;
            else
                cbEyePassword.Visibility = Visibility.Hidden;
        }

        private void Registration_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            App.registrationWindow.Show();
        }

        private void cbEye_Checked(object sender, RoutedEventArgs e)
        {
            ShowPassword();
        }

        private void cbEye_Unchecked(object sender, RoutedEventArgs e)
        {
            HidePassword();
        }

        void ShowPassword()
        {
            if (cbEyePassword.IsFocused)
            {
                txtVisiblePassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Hidden;
                txtVisiblePassword.Text = txtPassword.Password;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUserName.Text = StoreWithDataSources.Properties.Settings.Default.UserName;
            txtPassword.Password = StoreWithDataSources.Properties.Settings.Default.Password;
        }
    }
}
