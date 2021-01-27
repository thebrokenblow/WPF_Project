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
using System.Windows.Media.Animation; //Библиотека для анимации

namespace WPF_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
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
                    textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
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
                            using (var context = new ApplicationContext()) //Использование базы данных
                            {                                              //и выделение памяти для context - переменная для добавление и сохранения информации в базу даннных
                                var user = new User() //Выделение памяти для занесения информации в базу данных
                                {
                                    login = loginOfUser, //записываем в loginOfUser
                                    password = passwordOfUser, //записываем в passwordOfUser
                                    email = emailOfUser, //записываем emailOfUser
                                };
                                context.Users.Add(user); //Добавляем наши данные в базу данных
                                context.SaveChanges(); //Сохраняем наши данные в базу данных
                            }
                            HotelSearch hotelSearch = new HotelSearch(); //Создание новго объекта userPageWindow и выделение под него память
                            hotelSearch.Show(); //Отображение страницы, которая находится в объекте userPageWindow (Окно UserPageWindow (Личный кабинет))
                            Hide(); //Убрать нынешнее окно
                        }
                    }
                }
            }
        }
        private void Button_Transition_Auth_Click(object sender, RoutedEventArgs e) //Метод перехода к окну "Авторизация"
        {
            Window1 userAuth = new Window1(); //Создание новго объекта userAuth и выделение под него память
            userAuth.Show(); //Отображение страницы, которая находится в объекте userAuth (Окно Window1 (Авторизация пользователя))
            Hide(); //Убрать нынешнее окно
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}