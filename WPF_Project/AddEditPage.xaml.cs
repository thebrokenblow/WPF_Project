using System;
using System.Collections.Generic;
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

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public AddEditPage()
        {
            InitializeComponent();
            //if (selectedHotel != null)
            //    _currentHotel = selectedHotel;

            DataContext = _currentHotel;
            ComboCountries.ItemsSource = CourseProjectEntitiesFramework.GetContext().City.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.nameOfHotel))
                errors.AppendLine("Укажите название отеля");

            //if (_currentHotel.City == null)
            //    errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHotel.id == 0)
                CourseProjectEntitiesFramework.GetContext().Hotel.Add(_currentHotel);
            try
            {
                CourseProjectEntitiesFramework.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
