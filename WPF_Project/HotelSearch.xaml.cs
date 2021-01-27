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
    public partial class HotelSearch : Window
    {
        public HotelSearch()
        {
            InitializeComponent();
        }
        private void personalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalAccount personalAccount = new PersonalAccount(); //Создание новго объекта personalAccount и выделение под него память
            personalAccount.Show(); //Отображение страницы, которая находится в объекте personalAccount (Окно PersonalAccount (Личный кабинет))
            Hide(); //Убрать нынешнее окно
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}