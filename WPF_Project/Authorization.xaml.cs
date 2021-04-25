using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        /// <summary>
        /// Метод по обработки события нажатия на кнопку входа пользователя (авторизация)
        /// </summary>
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim().ToLower(); //Trim - удаляет пробелы слева и справа
            string password = passwordBox.Password.Trim();

            if (login.Length <= 5 || login.Length >= 25)
            {
                textBoxLogin.ToolTip = "The login is too short, enter more than 5 characters or more 25 characters.";   //ToolTip - подсказка  
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                if (password.Length <= 5 || password.Length >= 60)
                {
                    passwordBox.ToolTip = "The password is too short, enter more than 5 characters or or more 60 characters.";
                    var backgroundColor = new BrushConverter();
                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                }
                else
                { 
                    passwordBox.Background = Brushes.Transparent;
                    passwordBox.ToolTip = null;
                    Users authUser = null;
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        authUser = context.Users.Where(check => check.login == login && check.password == password).FirstOrDefault();
                    }
                    if (authUser != null)
                    {
                        using (ApplicationContext context = new ApplicationContext())
                        {
                           RecordOfUsers.recordOfUsers = context.Users.Where(x => x.login == login && x.password == password).Select(x => x).FirstOrDefault();
                        }
                        Uri HotelSearch = new Uri("HotelSearch.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(HotelSearch);
                    }
                    else
                        errorBox.Text = "Make sure the login and password you entered is correct.";
                }
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку перехода к регистрации пользователя
        /// </summary>
        private void Button_Transition_Reg_Click(object sender, RoutedEventArgs e) 
        {
            Uri Registration = new Uri("Registration.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Registration);
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}