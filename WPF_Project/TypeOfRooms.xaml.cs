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
    /// Логика взаимодействия для TypeOfRooms.xaml
    /// </summary>
    public partial class TypeOfRooms : Page
    {
        public TypeOfRooms()
        {
            InitializeComponent();
            var currentHotels = CourseProjectEntitiesDataBase.GetContext().TypeOfRoom.ToList();
            LViewTypeOfRooms.ItemsSource = currentHotels;
        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            var informationAboutTypeOfRoom = (TypeOfRoom)(((Button)sender).Tag);
        }
    }
}