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
using System.Windows.Shapes;

namespace WPF_Project
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //Trim - удаляет пробелы слева и справа
            string password = passwordBox.Password.Trim();

            if (login.Length <= 5)
            {
                textBoxLogin.ToolTip = "Слишком короткий логин, введите больше 5 символов";   //ToolTip - подсказка    
                textBoxLogin.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
            }
            if (password.Length <= 5)
            {
                passwordBox.ToolTip = "Слишком короткий пароль, введите больше 5 символов";
                passwordBox.Background = Brushes.Red;
            }
            else
            {
                passwordBox.Background = Brushes.Transparent;
                passwordBox.ToolTip = null;

            }
            User authUser = null; //Объект для работы с базой данных
            //using - Зактрытое окружение для подключения к базе данных
            //ApplicationContext conte = new ApplicationContext() - Создание оьъектра и выделение под него память
            //db - пременная для обращенияе к базе данных (db - DataBase) 
            using (ApplicationContext db = new ApplicationContext()) 
            {
                //check => check.Login == login && check.Password == password - создание переменной check, 
                //которая будет проверять, есть ли login и password 
                //в базе данных, которые ввёл пользователь
                //FirstOrDefault() - метод, который находите первую найденную запись, либо ничего
                authUser = db.Users.Where(check => check.Login == login && check.Password == password).FirstOrDefault();
            }
            if (authUser != null)
            {
                UserPageWindow userPageWindow = new UserPageWindow(); //Создание новго объекта userPageWindow и выделение под него память
                userPageWindow.Show(); //Отображение страницы, которая находится в объекте userPageWindow (Окно userPageWindow (Личный кабинет)) 
                Hide(); //Убрать нынешнее окно
            }
            else
                MessageBox.Show("Вы не вошли");
        }
        private void Button_Transition_Reg_Click(object sender, RoutedEventArgs e) //Метод перехода к окну "Регистрация пользователя"
        {
            MainWindow mainWindow = new MainWindow(); //Создание новго объекта mainWindow и выделение под него память
            mainWindow.Show(); //Отображение страницы, которая находится в объекте mainWindow (Окно MainWindow (Регистрация пользователя))
            Hide(); //Убрать нынешнее окно
        }
    }
}