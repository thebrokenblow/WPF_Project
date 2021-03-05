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
            DataContext = _currentHotel;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.nameOfHotel))
                errors.AppendLine("Укажите название отеля");

            if (string.IsNullOrWhiteSpace(_currentHotel.address))
                errors.AppendLine("Укажите адресс отеля");

            if (_currentHotel.countOfStars < 1 || _currentHotel.countOfStars > 5)
                errors.AppendLine("Количесво звёзд - число от 1 до 5");

            if (string.IsNullOrWhiteSpace(_currentHotel.phoneNumber))
                errors.AppendLine("Укажите адресс отеля");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHotel.id == 0)
                HotelsEntitiesFramework.GetContext().Hotel.Add(_currentHotel);
            try
            {
                HotelsEntitiesFramework.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Uri AddEditPage = new Uri("HotelsPage.xaml", UriKind.Relative);
                this.NavigationService.Navigate(AddEditPage); //Переход на страницу Добавляения записи об отеле
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Uri AddEditPage = new Uri("HotelsPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage); //Переход на страницу Добавляения записи об отеле
        }
    }
}
