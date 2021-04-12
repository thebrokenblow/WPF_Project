using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Are you sure you want to delete the following {hotelsForRemoving.Count()} items?", "Attention",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CourseProjectEntitiesDataBase.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    CourseProjectEntitiesDataBase.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");

                    DGridHotels.ItemsSource = CourseProjectEntitiesDataBase.GetContext().Hotel.ToList(); //Обращаемся к списку отелей, через контекст
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e) 
        {
            Uri AddEditPage = new Uri("AddEditPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage); //Переход на страницу Добавляения записи об отеле
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Uri AddEditPage = new Uri("AddEditPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage); //Переход на страницу Добавляения записи об отеле
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                CourseProjectEntitiesDataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = CourseProjectEntitiesDataBase.GetContext().Hotel.ToList();
            }
        }
    }
}