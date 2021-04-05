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
    public static class InfoAboutHotel
    {
        public static Hotel hotelInfo = null;
    }
    /// <summary>
    /// Логика взаимодействия для HotelList.xaml
    /// </summary>
    public partial class HotelList : Page
    {
        public HotelList()
        {
            InitializeComponent();
            var currentHotels = CourseProjectEntitiesFrameworkDataBase.GetContext().Hotel.ToList();
            LViewHotels.ItemsSource = currentHotels;
        }

        private void Button_Search_Room_Click(object sender, RoutedEventArgs e)
        {
            var informationAboutHotel = (Hotel)(((Button)sender).Tag);
            using (var db = new ApplicationContext())
            {
             //   var p = db.TypeOfRooms.Where(x => x.id == InfoAboutHotel.hotelInfo.id).Select(x => x.id).FirstOrDefault().ToString();
            }
        }
    }
}