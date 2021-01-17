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
    public partial class MainWindow : Window
    {
        ApplicationContext db; //Сылка на каш класс, для работы с базой данных
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            //string login = textBoxLogin.Text.Trim(); //Trim - удаляет пробелы слева и справа
            //string password = passwordBox.Password.Trim();
            //string passwordRepeat = passwordRepeatBox.Password.Trim();
            //string email = textBoxEmail.Text.Trim().ToLower(); //ToLower - перевод в нижний регист символы

            //if (login.Length <= 5)
            {
                //  textBoxLogin.ToolTip = "Слишком короткий логин, введите больше 5 символов"; //ToolTip - подсказка    
                //textBoxLogin.Background = Brushes.Red;
            }
            //else
            {
                //  textBoxLogin.Background = Brushes.Transparent;
                // textBoxLogin.ToolTip = null;
            }
            //if (password.Length <= 5)
            {
                //  passwordBox.ToolTip = "Слишком короткий пароль, введите больше 5 символов";
                //passwordBox.Background = Brushes.Red;
            }
            //else
            {
                //  passwordBox.Background = Brushes.Transparent;
                //passwordBox.ToolTip = null;
            }
            //if (password != passwordRepeat)
            {
                //  passwordRepeatBox.ToolTip = "Пароли не совпадают";
                // passwordRepeatBox.Background = Brushes.Red;
                //}
                //else
                //{
                //passwordRepeatBox.Background = Brushes.Transparent;
                // passwordRepeatBox.ToolTip = null;
                //}
                //if (email.Length <= 5 || !email.Contains("@") || !email.Contains("."))
                //{
                //textBoxEmail.ToolTip = "Это поле введено некорректно";
                //textBoxEmail.Background = Brushes.Red;
                //}
                //else
                //{
                //textBoxEmail.Background = Brushes.Transparent;
                //textBoxEmail.ToolTip = null;
                //}
                //User user = new User(login, password, email); //Выделение памяти под новую запись в базе данных
                //db.Users.Add(user); //Добавление новой записи в базу данных
                //db.SaveChanges(); //Сохраняем новую запись в базу данных
                UserPageWindow userPageWindow = new UserPageWindow(); //Создание новго объекта userPageWindow и выделение под него память
                userPageWindow.Show(); //Отображение страницы, которая находится в объекте userPageWindow (Окно UserPageWindow (Личный кабинет))
                Hide(); //Убрать нынешнее окно
            }
            //private void Button_Transition_Auth_Click(object sender, RoutedEventArgs e) //Метод перехода к окну "Авторизация"
            {
                Window1 userAuth = new Window1(); //Создание новго объекта userAuth и выделение под него память
                userAuth.Show(); //Отображение страницы, которая находится в объекте userAuth (Окно Window1 (Авторизация пользователя))
                Hide(); //Убрать нынешнее окно
            }
        }
    }
}
