using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для HotelSearch.xaml
    /// </summary>
    public partial class HotelSearch : Page
    {
        int countAdults = 1; //Количесво взрослых
        int countChildren = 0; //Количесво детей 
        int countRooms = 1; //Количесво комнат

        /// <summary>
        /// Метод для вывода информации на кнопку
        /// </summary>
        public void countOfAdultChildreanRoomBText(int countAdults, int countChildren, int countRooms)
        {
            countOfAdultChildreanRoomButton.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
            (countRooms).ToString() + "  room";
        }
        public HotelSearch()
        {
            InitializeComponent();
            textAdults.Text = (countAdults).ToString(); //Вывод информаци на кнопку об количесве Взрослых
            textChildren.Text = (countChildren).ToString(); //Вывод информаци на кнопку об количесве Детей
            textRooms.Text = (countRooms).ToString(); //Вывод информаци на кнопку об количесве Комнат
            countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms); //Вызов метода вывода информации на кнопку
            buttonCalender.Content = "Check-in  -  Check-out"; //Изначальный текст кнопки Календаря
        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки уменьшения количества Взрослых 
        /// </summary>
        private void Button_Adults_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults > 1)
            {
                countAdults--;
                textAdults.Text = (countAdults).ToString(); //Вывод информации на кнопку
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms); //Вызов метода вывода информации на кнопку
            }

        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки увеличения количества Взрослых 
        /// </summary>
        private void Button_Adults_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults < 15)
            {
                countAdults++;
                textAdults.Text = (countAdults).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки уменьшения количества Детей
        /// </summary>
        private void Button_Children_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren > 0)
            {
                countChildren--;
                textChildren.Text = (countChildren).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки увеличения количества Детей
        /// </summary>
        private void Button_Children_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren < 15)
            {
                countChildren++;
                textChildren.Text = (countChildren).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки уменьшения количества Комнат
        /// </summary>
        private void Button_Rooms_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms > 1)
            {
                countRooms--;
                textRooms.Text = (countRooms).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия кнопки увеличения количества Комнат
        /// </summary>
        private void Button_Rooms_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms < 15)
            {
                countRooms++;
                textRooms.Text = (countRooms).ToString();
                countOfAdultChildreanRoomBText(countAdults, countChildren, countRooms);
            }

        }
        /// <summary>
        /// Метод по обработки события поиска страны в ComboBox 
        /// </summary>
        void CbNaimTovCountry_TextChanged(object sender, RoutedEventArgs e)
        {
            CbNaimTovCountry.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CbNaimTovCountry.ItemsSource);
            cv.Filter = s => ((string)s).IndexOf(CbNaimTovCountry.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
        private void CbNaimTovCountry_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var tovararr = (from Сountry in context.Country select Сountry.nameOfCountry).ToList();
                CbNaimTovCountry.Items.Clear();
                CbNaimTovCountry.ItemsSource = tovararr;
            }
        }
        void OnComboBoxTextChangedCity(object sender, RoutedEventArgs e)
        {
            //     CbNaimTovCity.IsDropDownOpen = true;
            //     var tb = (TextBox)e.OriginalSource;
            //     tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            //     CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CbNaimTovCity.ItemsSource);
            //     cv.Filter = s => ((string)s).IndexOf(CbNaimTovCity.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
        /// <summary>
        /// Метод по обработки события вывода списка стран
        /// </summary>
        private void CbNaimTovCity_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelsEntitiesFramework())
            {
                //     var tovararr = (from City in context.City where City.idCountry== select City.nameOfCity ).ToList();
                //     CbNaimTovCountry.Items.Clear();
                //     CbNaimTovCity.ItemsSource = tovararr;
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку для перехода в личный кабинет
        /// </summary>
        private void personalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("PersonalAccount.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); //Переход на страницу Авторизации пользователя
        }
        private bool flagbuttonCalender = false;
        private bool flagcountOfAdultChildreanRommButton = false;
        /// <summary>
        /// Метод по обработки события нажатия на кнопку календаря
        /// </summary>
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
        /// <summary>
        /// Метод по обработки события нажатия на день в календаре
        /// </summary>
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectionDate = Calendar.SelectedDate;
            buttonCalender.Content = selectionDate.Value.Date.ToShortDateString();
        }
        /// <summary>
        /// Метод по обработки события нажатия на количесва Взрослых, Детей, Комнат
        /// </summary>
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
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void CbNaimTovCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (e.AddedItems[0] as ComboBoxItem).Content as String;
            // text = ("select") //Запрос получения id по строке 
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}