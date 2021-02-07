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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        /// <summary>
        /// Метод по обработки события нажатия на кнопку входа пользователя (авторизация)
        /// </summary>
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //Trim - удаляет пробелы слева и справа
            string password = passwordBox.Password.Trim();

            if (login.Length <= 5)
            {
                textBoxLogin.ToolTip = "The login is too short, enter more than 5 characters.";   //ToolTip - подсказка  
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                if (password.Length <= 5)
                {
                    passwordBox.ToolTip = "The password is too short, enter more than 5 characters.";
                    var backgroundColor = new BrushConverter();
                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                }
                else
                {
                    passwordBox.Background = Brushes.Transparent;
                    passwordBox.ToolTip = null;
                    Users authUser = null; //Объект для работы с базой данных
                                          //using - Зактрытое окружение для подключения к базе данных
                                          //ApplicationContext conte = new ApplicationContext() - 
                                          //Создание оьъектра и выделение под него память
                                          //db - пременная для обращенияе к базе данных (db - DataBase) 
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        //check => check.Login == login && check.Password == password - создание переменной check, 
                        //которая будет проверять, есть ли login и password 
                        //в базе данных, которые ввёл пользователь
                        //FirstOrDefault() - метод, который находите первую найденную запись, либо ничего
                        authUser = context.Users.Where(check => check.login == login && check.password == password).FirstOrDefault();
                    }
                    if (authUser != null)
                    {
                        Uri HotelSearch = new Uri("HotelSearch.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(HotelSearch); //Переход на страницу поиска отелей
                    }
                    else
                        errorBox.Text = "Make sure the login and password you entered is correct."; //Сообщение об ошибке неправельно введёееых данных
                }
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку перехода к регистрации пользователя
        /// </summary>
        private void Button_Transition_Reg_Click(object sender, RoutedEventArgs e) //Метод перехода к окну "Регистрация пользователя"
        {
            Uri Registration = new Uri("Registration.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Registration); //Переход на страницу Авторизации пользователя
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}