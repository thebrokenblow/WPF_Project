using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                    CourseProjectDataBase.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    CourseProjectDataBase.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");

                    DGridHotels.ItemsSource = CourseProjectDataBase.GetContext().Hotel.ToList(); //Обращаемся к списку отелей, через контекст
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
            this.NavigationService.Navigate(AddEditPage); 
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Uri AddEditPage = new Uri("AddEditPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage);
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                CourseProjectDataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = CourseProjectDataBase.GetContext().Hotel.ToList();
            }
        }
    }
}