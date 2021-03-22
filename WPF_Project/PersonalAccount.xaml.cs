using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Page
    {
        public PersonalAccount()
        {
            InitializeComponent();
            using (var db = new ApplicationContext())
            {
                var emailstr = db.Users.Where(x => x.idOfUsers == Info.userinfo.idOfUsers).Select(x => x.email).FirstOrDefault().ToString();
                var surmane = db.Users.Where(x => x.idOfUsers == Info.userinfo.idOfUsers).Select(x => x.surname).FirstOrDefault().ToString();
                var name = db.Users.Where(x => x.idOfUsers == Info.userinfo.idOfUsers).Select(x => x.name).FirstOrDefault().ToString();
                emailText.Text = emailstr;
                surnameText.Text = surmane;
                nameText.Text = name;
            }
           
        }
        /// <summary>
        /// Метод по обработки события нажатия на кнопку перехода к поиску отелей
        /// </summary>
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("HotelSearch.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount); //Переход на страницу Авторизации пользователя
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            string surnameOfUser = surnameText.Text;
            string nameOfUser = nameText.Text;
            string patronymicOfUser = patronymicText.Text;
            string phoneNumberOfUser = phoneNumberText.Text;
            using (ApplicationContext context = new ApplicationContext())
            {
                (from p in context.Users where p.idOfUsers == Info.userinfo.idOfUsers select p).ToList().ForEach(x => x.surname = surnameOfUser);
                //Context.SaveChanges();
            }
        }
    }
}