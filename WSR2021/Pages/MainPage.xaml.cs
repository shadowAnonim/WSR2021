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
using WSR2021.Forms;

namespace WSR2021.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Utils.db.ComboView.Load();
            List<ComboView> list = Utils.db.ComboView.ToList();
            nameTextBox.ItemsSource = list;
            MessageBox.Show("ОК");
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            comboViewDataGrid.Items.Add(nameTextBox.SelectedItem);
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserForm form = new AddUserForm(null);
            form.ShowDialog();
            Utils.db.ComboView.Load();
            List<ComboView> list = Utils.db.ComboView.ToList();
            nameTextBox.ItemsSource = list;
            nameTextBox.SelectedIndex = nameTextBox.Items.Count - 1;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var select = comboViewDataGrid.SelectedItem as ComboView;
            if (select == null)
            {
                MessageBox.Show("Выберите");
                return;
            }
            User user = Utils.db.User.FirstOrDefault(el => el.id == select.id);
            AddUserForm form = new AddUserForm(user);
            form.ShowDialog();
        }
    }
}
