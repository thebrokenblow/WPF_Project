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
    /// Логика взаимодействия для HotelList.xaml
    /// </summary>
    public class RecordOfHotel
    {
        public static int id;
        public static string address;
        public static string name;
        public static string description;
        public static string phone;
        public static int stars;
        public RecordOfHotel(int idOfHotel, string addresOfHotel, string nameOfHotel, string hotelDescription, string phoneNumber, int countOfStars)
        {
            id = idOfHotel;
            address = addresOfHotel;
            name = nameOfHotel;
            description = hotelDescription;
            phone = phoneNumber;
            stars = countOfStars;
        }
    }
    public partial class HotelList : Page
    {
        public HotelList()
        {
            InitializeComponent();
            LViewHotels.ItemsSource = CourseProjectDataBase.GetContext().Hotel.Where(x => x.idOfCity == AdditionalRecordAboutHotel.id).Select(x => x).ToList();
        }

        private void Button_Search_Room_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CourseProjectDataBase())
            {
                var availableRooms = context.ListOfRooms.Where(x => x.dataStart < AdditionalRecordAboutHotel.dataStart && x.dataEnd < AdditionalRecordAboutHotel.dataEnd).Select(x => x).FirstOrDefault();
                if (availableRooms == null)
                    MessageBox.Show("There are no available rooms on the selected date, select another date");

                else
                {
                    var hotel = (Hotel)(((Button)sender).Tag);
                    RecordOfHotel hotel1 = new RecordOfHotel(hotel.id, hotel.address, hotel.nameOfHotel, hotel.hotelDescription, hotel.phoneNumber, hotel.countOfStars);
                    Uri TypeOfRooms = new Uri("TypeOfRooms.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(TypeOfRooms);
                }
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Uri HotelSearch = new Uri("HotelSearch.xaml", UriKind.Relative);
            this.NavigationService.Navigate(HotelSearch);
        }
    }
}