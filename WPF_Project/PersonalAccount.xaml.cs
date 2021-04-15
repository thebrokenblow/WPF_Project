using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            using (var context = new CourseProjectEntitiesDataBase())
            {
                var email = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.email).FirstOrDefault()?.ToString();
                var surname= context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.surname).FirstOrDefault()?.ToString();
                var name = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.name).FirstOrDefault()?.ToString();
                emailText.Text = email;
                surnameText.Text = surname;
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

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            string surnameOfUser = surnameText.Text;
            using (ApplicationContext context = new ApplicationContext())
            {
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.surname = surnameOfUser);
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
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}