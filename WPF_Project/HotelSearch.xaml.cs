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
        int countAdults = 1;
        int countChildren = 0;
        int countRooms = 1;
        public void mainButtonText(int countAdults, int countChildren, int countRooms)
        {
            mainButton.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
            (countRooms).ToString() + "  room";
        }
        public HotelSearch()
        {
            InitializeComponent();
            textAdults.Text = (countAdults).ToString();
            textChildren.Text = (countChildren).ToString();
            textRooms.Text = (countRooms).ToString();
            mainButtonText(countAdults, countChildren, countRooms);
            buttonCalender.Content = "Check-in  -  Check-out";
        }
        private void Button_Adults_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults > 1)
            {
                countAdults--;
                textAdults.Text = (countAdults).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }
        }
        private void Button_Adults_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults < 15)
            {
                countAdults++;
                textAdults.Text = (countAdults).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }
        }
        private void Button_Children_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren > 0)
            {
                countChildren--;
                textChildren.Text = (countChildren).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }
        }
        private void Button_Children_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren < 15)
            {
                countChildren++;
                textChildren.Text = (countChildren).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }
        }
        private void Button_Rooms_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms > 1)
            {
                countRooms--;
                textRooms.Text = (countRooms).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }
        }
        private void Button_Rooms_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms < 15)
            {
                countRooms++;
                textRooms.Text = (countRooms).ToString();
                mainButtonText(countAdults, countChildren, countRooms);
            }

        }
        void OnComboBoxTextChanged(object sender, RoutedEventArgs e)
        {
            CbNaimTov.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CbNaimTov.ItemsSource);
            cv.Filter = s => ((string)s).IndexOf(CbNaimTov.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
        private void CbNaimTov_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var tovararr = (from Сountry in context.Country select Сountry.nameOfCountry).ToList();
                CbNaimTov.Items.Clear();
                CbNaimTov.ItemsSource = tovararr;
            }
        }
       /* void OnComboBoxTextChanged1(object sender, RoutedEventArgs e)
        {
            CbNaimTov1.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CbNaimTov1.ItemsSource);
            cv.Filter = s => ((string)s).IndexOf(CbNaimTov1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
        private void CbNaimTov_Loaded1(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var tovararr1 = (from City in context.City select City.nameOfCity).ToList();
                CbNaimTov1.Items.Clear();
                CbNaimTov1.ItemsSource = tovararr1;
            }
        } */
        /// <summary>
        /// Метод по обработки события нажатия на кнопку прехода к личному кабинету пользователя
        /// </summary>
        private void personalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("PersonalAccount.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); //Переход на страницу Авторизации пользователя
        }
        private bool flagFirstButton = false;
        private bool flagSecondButton = false;
        private void mainButoon1_Click(object sender, RoutedEventArgs e)
        {
            if (flagFirstButton == false)
            {
                mainBorder1.Visibility = Visibility.Visible;
                flagFirstButton = true;
            }
            else
            {
                mainBorder1.Visibility = Visibility.Collapsed;
                flagFirstButton = false;
            }
        }
        private void mainButoon_Click(object sender, RoutedEventArgs e)
        {
            if (flagSecondButton == false)
            {
                mainBorder.Visibility = Visibility.Visible;
                flagSecondButton = true;
            }
            else
            {
                mainBorder.Visibility = Visibility.Collapsed;
                flagSecondButton = false;
            }
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectionDate = Calendar.SelectedDate;
            buttonCalender.Content = selectionDate.Value.Date.ToShortDateString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}