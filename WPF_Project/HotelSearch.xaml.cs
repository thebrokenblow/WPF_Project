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
    /// Логика взаимодействия для HotelSearch.xaml
    /// </summary>
    public partial class HotelSearch : Page
    {
        // static void mainButtonText(int countAdults,
        //int countChildren,
        //int countRooms) {
        //mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
        //(countRooms).ToString() + "  room";

        int countAdults = 1;
        int countChildren = 0;
        int countRooms = 1;
        public HotelSearch()
        {
            InitializeComponent();
            textAdults.Text = (countAdults).ToString();
            textChildren.Text = (countChildren).ToString();
            textRooms.Text = (countRooms).ToString();
            mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
        }
        private void Button_Adults_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults > 1)
            {
                countAdults--;
                textAdults.Text = (countAdults).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }
        }
        private void Button_Adults_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countAdults < 15)
            {
                countAdults++;
                textAdults.Text = (countAdults).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }
        }
        private void Button_Children_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren > 0)
            {
                countChildren--;
                textChildren.Text = (countChildren).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }
        }
        private void Button_Children_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countChildren < 15)
            {
                countChildren++;
                textChildren.Text = (countChildren).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }
        }
        private void Button_Rooms_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms > 1)
            {
                countRooms--;
                textRooms.Text = (countRooms).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }
        }
        private void Button_Rooms_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countRooms < 15)
            {
                countRooms++;
                textRooms.Text = (countRooms).ToString();
                mainButoon.Content = (countAdults).ToString() + "  adult  ·  " + (countChildren).ToString() + "  children  ·  " +
                (countRooms).ToString() + "  room";
            }

        }
        /*public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }
        private void mainButoon_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Convert();
        } */
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
                var tovararr = (from Users in context.Users select Users.login).ToList();
                CbNaimTov.Items.Clear();
                CbNaimTov.ItemsSource = tovararr;
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку прехода к личному кабинету пользователя
        /// </summary>
        private void personalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("PersonalAccount.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); //Переход на страницу Авторизации пользователя
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void mainButoon_Click(object sender, RoutedEventArgs e)
        {
            mainBorder.Visibility = Visibility;
        }
    }
}