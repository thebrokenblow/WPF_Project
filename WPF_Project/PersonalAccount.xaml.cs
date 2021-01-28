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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Page
    {
        public PersonalAccount()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку перехода к поиску отелей
        /// </summary>
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("HotelSearch.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); //Переход на страницу Авторизации пользователя
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}
