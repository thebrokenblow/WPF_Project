using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Project
{

    public class informationAboutHotel 
    {
        public static int id;
        public static string Country;
        public static string City;
        public static DateTime dataBegin;
        public static DateTime dataEnd;
        public static int countOfAdults;
        public static int countOfChildren;
        public static int countOfRooms;
        public informationAboutHotel(int idOfCity, string nameOfCountry, string nameOfCity, DateTime firstDate, DateTime lastDate, 
            int countAdults, int countChildren, int countRooms)
        {
            id = idOfCity;
            Country = nameOfCountry;
            City = nameOfCity;
            dataBegin = firstDate;
            dataEnd = lastDate;
            countOfAdults = countAdults;
            countOfChildren = countChildren;
            countOfRooms = countRooms;
        }
    }

    public partial class HotelSearch : Page
    {
        int countAdults = 1; 
        int countChildren = 0;  
        int countRooms = 1;
        
        public void countOfAdultChildreanRoomBText(int countAdults, int countChildren, int countRooms)
        {
            countOfAdultChildreanRoomButton.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
            (countRooms).ToString() + "  room";
        }

        public HotelSearch()
        {
            InitializeComponent();
      
            CbNaimTovCountry.ItemsSource = CourseProjectEntitiesDataBase.GetContext().Сountry.ToList();
            CbNaimTovCity.ItemsSource = CourseProjectEntitiesDataBase.GetContext().City.ToList();
            DateTime date = DateTime.Now;
            Calendar.DisplayDateStart = date;
            textAdults.Text = (countAdults).ToString();
            textChildren.Text = (countChildren).ToString(); 
            textRooms.Text = (countRooms).ToString(); 
            countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms); 
            buttonCalender.Content = "Check-in  -  Check-out"; 
        }

        private void Button_Adults_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults > 1)
            {
                countAdults--;
                textAdults.Text = (countAdults).ToString(); 
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms); 
            }
        }

        private void Button_Adults_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults < 15)
            {
                countAdults++;
                textAdults.Text = (countAdults).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }

        private void Button_Children_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren > 0)
            {
                countChildren--;
                textChildren.Text = (countChildren).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }

        private void Button_Children_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren < 15)
            {
                countChildren++;
                textChildren.Text = (countChildren).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }

        private void Button_Rooms_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms > 1)
            {
                countRooms--;
                textRooms.Text = (countRooms).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }

        private void Button_Rooms_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms < 15)
            {
                countRooms++;
                textRooms.Text = (countRooms).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        } 
       
        private bool flagbuttonCalender = false;
        private bool flagcountOfAdultChildreanRommButton = false;
        private void buttonCalender_Click(object sender, RoutedEventArgs e)
        {
            if (flagbuttonCalender == false)
            {
                borderCalender.Visibility = Visibility.Visible;
                flagbuttonCalender = true;
            }
            else
            {
                borderCalender.Visibility = Visibility.Collapsed;
                flagbuttonCalender = false;
            }
        }

        DateTime firstDate;
        DateTime lastDate;
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            firstDate = Calendar.SelectedDates.OrderBy(k => k).First();
            lastDate = Calendar.SelectedDates.OrderBy(k => k).Last();
            buttonCalender.Content = firstDate.ToString("M") + " - " + lastDate.ToString("M");
        }

        private void countOfAdultChildreanRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (flagcountOfAdultChildreanRommButton == false)
            {
                borderCountOfAdultChildreanRoomButton.Visibility = Visibility.Visible;
                flagcountOfAdultChildreanRommButton = true;
            }
            else
            {
                borderCountOfAdultChildreanRoomButton.Visibility = Visibility.Collapsed;
                flagcountOfAdultChildreanRommButton = false;
            }
        }

        private void CbNaimTovCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string text = (e.AddedItems[0] as ComboBoxItem).Content as String;
            //MessageBox.Show(text);
            /*var p = context.Country.Where(x => x.nameOfCountry == nameOfCountry).Select(x => x).FirstOrDefault();
            text = from City in City 
                   where City.id = Hotel.id
                   select City;*/
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            string nameOfCountry = CbNaimTovCountry.Text;
            if (nameOfCountry == "")
                errorTextBlock.Text = "Select The Country";
            else
            {
                errorTextBlock.Text = "";
                string nameOfCity = CbNaimTovCity.Text;
                if (nameOfCity == "")
                    errorTextBlock.Text = "Select The City";
                else 
                {
                    errorTextBlock.Text = "";
                    if (firstDate == DateTime.Parse("01.01.0001 0:00:00"))    
                    errorTextBlock.Text = "Select The Start Date";
                    else
                    {
                        errorTextBlock.Text = "";
                        if (lastDate == DateTime.Parse("01.01.0001 0:00:00"))
                            errorTextBlock.Text = "Select The End Date";
                        else
                        {
                            errorTextBlock.Text = "";
                            if (firstDate == lastDate)
                                errorTextBlock.Text = "Choose Different Dates";
                            else
                            {
                                errorTextBlock.Text = "";
                                using (var context = new CourseProjectEntitiesDataBase())
                                {
                                    var hotel = context.City.Where(x => x.nameOfCity == nameOfCity).Select(x => x).FirstOrDefault();
                                    informationAboutHotel informationAboutHotel = new informationAboutHotel(hotel.id, nameOfCountry, nameOfCity, firstDate, lastDate, countAdults, countChildren, countRooms);
                                }
                                Uri HotelsList = new Uri("HotelsList.xaml", UriKind.Relative);
                                this.NavigationService.Navigate(HotelsList);
                            }
                        }
                    }
                }
            }
           
        }

        private void Personal_Account_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("PersonalAccount.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); 
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri Registration = new Uri("Authorization.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Registration);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}