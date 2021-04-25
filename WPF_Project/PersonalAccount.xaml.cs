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
            using (var context = new CourseProjectDataBase())
            {
                surnameText.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.surname).FirstOrDefault()?.ToString();
                nameText.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.name).FirstOrDefault()?.ToString();
                patronymicText.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.patronymic).FirstOrDefault()?.ToString();
                emailText.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.email).FirstOrDefault()?.ToString();
                phoneNumberText.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.phoneNumber).FirstOrDefault()?.ToString();
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
            string nameOfUser = nameText.Text;
            string patronymicOfUser = patronymicText.Text;
            string emailOfUser = emailText.Text;
            string phoneOfUser = phoneNumberText.Text;
            using (var context = new CourseProjectDataBase())
            {
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.surname = surnameOfUser);
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.name = nameOfUser);
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.patronymic = patronymicOfUser);
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.email = emailOfUser);
                (from x in context.Users where x.id == InfoOfUsers.userInfo.id select x).ToList().ForEach(x => x.phoneNumber = phoneOfUser);
                context.SaveChanges();
            }
        }
        private void uploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            /*int width = 1024;
            int height = 768;
            Bitmap imgNoise = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmpData = imgNoise.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr scan = bmpData.Scan0;

            Random rand = new Random();
            byte color = 0;

            unsafe
            {
                byte* ptr = (byte*)scan.ToPointer();
                byte* ptrHelper = ptr;

                for (int y = 0; y < height; y++) //Порядок перебора критичен, т. к. изображение хранится в памяти построчно
                {
                    for (int x = 0; x < width; x++)
                    {
                        color = (byte)rand.Next(0, 256);
                        *(ptr++) = color; //Присвоение красного компонента цвета и установка указателя на следующий байт
                        *(ptr++) = color; //Присвоение зелёного компонента цвета и установка указателя на следующий байт
                        *(ptr++) = color; //Присвоение синего компонента цвета и установка указателя на следующий байт
                    }

                    ptrHelper += bmpData.Stride;
                    ptr = ptrHelper;
                }
            }

            imgNoise.UnlockBits(bmpData);
            /*var fileDialog = new OpenFileDialog();
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
            }*/
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}