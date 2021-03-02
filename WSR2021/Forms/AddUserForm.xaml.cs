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
        public AddUserForm()
        {
            InitializeComponent();
            _user = new User();
            _user.role = 0;
            grid1.DataContext = _user;
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
            Utils.db.User.Load();
            Utils.db.User.Add(_user);
            Utils.db.SaveChanges();
            this.Close();
        }
    }
}
