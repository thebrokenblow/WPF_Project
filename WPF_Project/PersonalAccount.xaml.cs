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
using System.Windows.Shapes;

namespace WPF_Project
{
    public partial class PersonalAccount : Window
    {
        public PersonalAccount()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            HotelSearch hotelSearch = new HotelSearch(); //Создание новго объекта hotelSearch и выделение под него память
            hotelSearch.Show(); //Отображение страницы, которая находится в объекте hotelSearch (Окно HotelSearch (Поиск отелей)) 
            Hide(); //Убрать нынешнее окно
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
