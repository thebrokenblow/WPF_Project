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
    public partial class Registration : Page
    {
        /// <summary>
        /// Логика взаимодействия для Registration.xaml
        /// </summary>
        public Registration()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку регистрации пользователя
        /// </summary>
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string loginOfUser = textBoxLogin.Text.Trim(); //loginOfUser - логин, который вводит пользователь Trim - удаляет пробелы слева и справа
            string passwordOfUser = passwordBox.Password.Trim(); //passwordOfUser - пароль, который вводит пользователь  
            string passwordOfUserRepeat = passwordRepeatBox.Password.Trim(); //passwordOfUserRepeat - повторный пароль, который вводит пользователь
            string emailOfUser = textBoxEmail.Text.Trim().ToLower(); //emailOfUser - email, который вводит пользователь ToLower - перевод в нижний регист символы

            if (loginOfUser.Length <= 5) //Проверка на длину логина пользователя
            {
                textBoxLogin.ToolTip = "The login is too short, enter more than 5 characters."; //ToolTip - подсказка при наведении на поле    
                var backgroundColor = new BrushConverter(); //создание объекта на основе BrushConverter и выделением под него память 
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent; //Transparent - очищение заднего фона текстового блока
                textBoxLogin.ToolTip = null; //очищаем подсказку
                if (passwordOfUser.Length <= 5)
                {
                    passwordBox.ToolTip = "The password is too short, enter more than 5 characters.";
                    var backgroundColor = new BrushConverter(); //создание объекта на основе BrushConverter и выделением под него память 
                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
                }
                else
                {
                    passwordBox.Background = Brushes.Transparent; //Transparent - очищение заднего фона текстового блока
                    passwordBox.ToolTip = null; //очищаем подсказку
                    if (passwordOfUser != passwordOfUserRepeat)
                    {
                        passwordRepeatBox.ToolTip = "Passwords don't match.";
                        var backgroundColor = new BrushConverter(); //создание объекта на основе BrushConverter и выделением под него память 
                        passwordRepeatBox.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
                    }
                    else
                    {
                        passwordRepeatBox.Background = Brushes.Transparent; //Transparent - очищение заднего фона текстового блока
                        passwordRepeatBox.ToolTip = null; //очищаем подсказку
                        if (emailOfUser.Length <= 5 || !emailOfUser.Contains("@") || !emailOfUser.Contains("."))
                        {
                            textBoxEmail.ToolTip = "Incorrectly entered email.";
                            var backgroundColor = new BrushConverter(); //создание объекта на основе BrushConverter и выделением под него память 
                            textBoxEmail.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
                        }
                        else
                        {
                            textBoxEmail.Background = Brushes.Transparent; //Transparent - очищение заднего фона текстового блока
                            textBoxEmail.ToolTip = null; //очищаем подсказку
                            Users regUser = null; //Объект для работы с базой данных
                                                  //using - Зактрытое окружение для подключения к базе данных
                                                  //ApplicationContext conte = new ApplicationContext() - 
                                                  //Создание объектра и выделение под него память
                                                  //context - пременная для обращенияе к базе данных 
                            using (ApplicationContext context = new ApplicationContext())
                            {
                                //check => check.Login == login && check.Password == password - создание переменной check, 
                                //которая будет проверять, есть ли login и password 
                                //в базе данных, которые ввёл пользователь
                                //FirstOrDefault() - метод, который находите первую найденную запись, либо ничего
                                regUser = context.Users.Where(check => check.login == loginOfUser || check.email == emailOfUser).FirstOrDefault();
                                if (regUser == null)
                                {
                                    var user = new Users() //Выделение памяти для занесения информации в базу данных
                                    {
                                        login = loginOfUser, //записываем в loginOfUser
                                        password = passwordOfUser, //записываем в passwordOfUser
                                        email = emailOfUser, //записываем emailOfUser
                                    };
                                    context.Users.Add(user); //Добавляем наши данные в базу данных
                                    context.SaveChanges(); //Сохраняем наши данные в базу данных
                                    Uri HotelSearch = new Uri("HotelSearch.xaml", UriKind.Relative);
                                    this.NavigationService.Navigate(HotelSearch); //Переход на страницу Авторизации пользователя
                                }
                                else
                                    errorBox.Text = "This login or email is already registered"; //Сообщение об ошибке неправельно введёееых данных
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку перехода на авторизацию пользователя (Если пользователь уже зарегистрирован)
        /// </summary>
        private void Button_Transition_Auth_Click(object sender, RoutedEventArgs e) //Метод перехода к окну "Авторизация"
        {
            Uri Authorization = new Uri("Authorization.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Authorization); //Переход на страницу Авторизации пользователя
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}