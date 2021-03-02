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
using System.Windows.Shapes;

namespace WSR2021.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddUserForm.xaml
    /// </summary>
    public partial class AddUserForm : Window
    {
        User _user;
        bool edit = true;
        public AddUserForm(User user)
        {
            InitializeComponent();
            userRoleTextBox.ItemsSource = Utils.db.Role.ToList();
            if (user == null)
            {
                _user = new User();
                user.role = 0;
                edit = false;
            }
            else
            {
                _user = user;
                user.role = 0;
                edit = true;
            }
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
        //    // Загрузите данные, установив свойство CollectionViewSource.Source:
        //    // userViewSource.Source = [универсальный источник данных]

        //    grid1.DataContext = _user;
        //}

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                Utils.db.User.Load();
                Utils.db.SaveChanges();
                this.Close();
            }
            else
            {
                Utils.db.User.Load();
                Utils.db.User.Add(_user);
                Utils.db.SaveChanges();
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // userViewSource.Source = [универсальный источник данных]
            grid1.DataContext = _user;

        }
    }
}
