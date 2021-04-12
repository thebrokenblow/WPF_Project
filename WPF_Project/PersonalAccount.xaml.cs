using Microsoft.Win32;
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
                //var emailstr = db.Users.Where(x => x.id == Info.userinfo.id).Select(x => x.email).FirstOrDefault()?.ToString();
                //var surname= db.Users.Where(d => d.id == Info.userinfo.id).Select(d => d.surname).FirstOrDefault()?.ToString();
                //var name = db.Users.Where(x => x.id == Info.userinfo.id).Select(x => x.name).FirstOrDefault()?.ToString();
                //emailText.Text = emailstr;
                //surnameText.Text = surname;
                //nameText.Text = name;
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
            using (ApplicationContext context = new ApplicationContext())
            {
                (from p in context.Users where p.id == Info.userInfo.id select p).ToList().ForEach(x => x.surname = surnameOfUser);
                context.SaveChanges();
            }
        }
        private void uploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
            fileDialog.InitialDirectory = @"C:\Users\User\Desktop\C#_Projects\Фото отелей";
            fileDialog.Title = "Пример использования OpenFileDialog ";
            if (fileDialog.ShowDialog() != true)
                MessageBox.Show("Не выбран файл");
            else 
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    //(from p in context.Users where p.id == Info.userinfo.id select p).ToList().ForEach(x => x.image = fileDialog.FileName);
                    //context.SaveChanges();
                }
            }
        }
    }
}