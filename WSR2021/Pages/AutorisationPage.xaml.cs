using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSR2021.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        public AutorisationPage()
        {
            InitializeComponent();
        }

        private void passwordCb_Checked(object sender, RoutedEventArgs e)
        {
            if (passwordPb.Visibility == Visibility.Visible)
            {
                passwordTb.Text = passwordPb.Password;
                passwordPb.Visibility = Visibility.Hidden;
            }
        }

        private void passwordCb_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordPb.Password = passwordTb.Text;
            passwordPb.Visibility = Visibility.Visible;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.db.User.Load();
            passwordTb.Text = passwordPb.Password;
            var result = Utils.db.User.FirstOrDefault(user => user.login == loginTb.Text && user.password == passwordTb.Text);
            if (result == null)
            {
                MessageBox.Show("Error");
                return;
            }
            NavigationService.Navigate(new MainPage());
        }
    }
}
