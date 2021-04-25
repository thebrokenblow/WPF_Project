using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для Receipt.xaml
    /// </summary>
    public class RoomsId
    {
        public static int id;
        public RoomsId(int idOfRooms)
        {
            id = idOfRooms; 
        }
    }
    public partial class Receipt : Page
    {
        public Receipt()
        {
            InitializeComponent();

            using (var context = new CourseProjectDataBase())
            {
                nameOfUser.Text = context.Users.Where(x => x.id == RecordOfUsers.recordOfUsers.id).Select(x => x.name).FirstOrDefault()?.ToString(); ;
                surnameOfUsers.Text = context.Users.Where(x => x.id == RecordOfUsers.recordOfUsers.id).Select(x => x.surname).FirstOrDefault()?.ToString(); ;
                emailOfUsers.Text = context.Users.Where(x => x.id == RecordOfUsers.recordOfUsers.id).Select(x => x.email).FirstOrDefault()?.ToString();
                phoneOfUsers.Text = context.Users.Where(x => x.id == RecordOfUsers.recordOfUsers.id).Select(x => x.phoneNumber).FirstOrDefault()?.ToString();
            }

            dateOfBegin.Text = AdditionalRecordAboutHotel.dataStart.ToString("M");
            dateOfEnd.Text = AdditionalRecordAboutHotel.dataEnd.ToString("M");
            numberOfAdults.Text = AdditionalRecordAboutHotel.countOfAdults.ToString();
            numberOfChildren.Text = AdditionalRecordAboutHotel.countOfChildren.ToString();
            numberOfRomms.Text = AdditionalRecordAboutHotel.countOfRooms.ToString();
            adressOfHotel.Text = "Adress Of Hotel: " + RecordOfHotel.address;
            nameOfHotel.Text = "Name Of Hotel: " + RecordOfHotel.name;
            phoneOfHotel.Text = "Phone: " + RecordOfHotel.phone;
            countOfStars.Text = "Stars: " + RecordOfHotel.stars.ToString();
            country.Text = "Contry: " + AdditionalRecordAboutHotel.Country;
            city.Text = "City: " + AdditionalRecordAboutHotel.City;
            typeOfRoom.Text = RecordTypeOfRooms.name;
            pricePerDay.Text = RecordTypeOfRooms.price.ToString(".00", CultureInfo.InvariantCulture);
            finalPrice.Text = (AdditionalRecordAboutHotel.countOfRooms * RecordTypeOfRooms.price * System.Convert.ToDecimal(((AdditionalRecordAboutHotel.dataEnd -
                AdditionalRecordAboutHotel.dataStart).TotalDays))).
                ToString(".00", CultureInfo.InvariantCulture);
        }
       
        private void Save_And_To_Book_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var toBook = new CourseProjectDataBase())
            {
                var recordHotelRoom = toBook.ListOfRooms.Where(x => x.dataStart < AdditionalRecordAboutHotel.dataStart 
                                      && x.dataEnd < AdditionalRecordAboutHotel.dataEnd
                                      && x.idOfType == RecordTypeOfRooms.id).Select(x => x).FirstOrDefault();

                (from x in toBook.ListOfRooms 
                 where x.idOfHotel == RecordOfHotel.id 
                 && x.idOfType == RecordTypeOfRooms.id 
                 && x.id == recordHotelRoom.id
                 && x.dataStart < AdditionalRecordAboutHotel.dataStart
                 && x.dataEnd < AdditionalRecordAboutHotel.dataEnd  
                 select x).ToList().ForEach(x => x.dataEnd = AdditionalRecordAboutHotel.dataEnd);

                RoomsId rooms = new RoomsId(recordHotelRoom.id);

                (from x in toBook.ListOfRooms
                 where x.idOfHotel == RecordOfHotel.id 
                 && x.idOfType == RecordTypeOfRooms.id
                 && x.id == recordHotelRoom.id
                 && x.dataStart < AdditionalRecordAboutHotel.dataStart
                 && x.dataEnd < AdditionalRecordAboutHotel.dataEnd
                 select x).ToList().ForEach(x => x.dataStart = AdditionalRecordAboutHotel.dataStart);

                toBook.SaveChanges(); 
            }
            
            using (var context = new CourseProjectDataBase())
            {
                var reservation = new Reservation()
                {
                    idOfUsers = RecordOfUsers.recordOfUsers.id,
                    idOfHotel = RecordOfHotel.id,
                    idOfTypeOfRooms = RecordTypeOfRooms.id,
                    idOfRooms = RoomsId.id,
                    numberOfAdults = AdditionalRecordAboutHotel.countOfAdults,
                    numberOfChildren = AdditionalRecordAboutHotel.countOfChildren,
                    numberOfRoomsBooked = AdditionalRecordAboutHotel.countOfRooms,
                    fullPrice = (AdditionalRecordAboutHotel.countOfRooms * RecordTypeOfRooms.price * System.Convert.ToDecimal(((AdditionalRecordAboutHotel.dataEnd -
                    AdditionalRecordAboutHotel.dataStart).TotalDays))),
                    startDate = AdditionalRecordAboutHotel.dataStart,
                    endDate = AdditionalRecordAboutHotel.dataEnd,
                };
                context.Reservation.Add(reservation);
                context.SaveChanges();
            }
            Uri HotelSearch = new Uri("HotelSearch.xaml", UriKind.Relative);
            this.NavigationService.Navigate(HotelSearch);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri Receipt = new Uri("TypeOfRooms.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Receipt);
        }
    }
}