﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для TypeOfRooms.xaml
    /// </summary>
    public class RecordTypeOfRooms
    {
        public static int id;
        public static decimal price;
        public static string name;
        public RecordTypeOfRooms(int idTypeOfRoom, decimal pricePerDay, string roomName)
        {
            id = idTypeOfRoom;
            price = pricePerDay;
            name = roomName;
        }
    }
    
    public partial class TypeOfRooms : Page 
    {
        public TypeOfRooms()
        {
            InitializeComponent();
 
            LViewTypeOfRooms.ItemsSource = CourseProjectDataBase.GetContext().TypeOfRoom.Where(x => x.idOfHotel == RecordOfHotel.id).Select(x => x).ToList();
        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
                var typeOfRoom = (TypeOfRoom)(((Button)sender).Tag);
                RecordTypeOfRooms recordTypeOfRoom = new RecordTypeOfRooms(typeOfRoom.id, typeOfRoom.pricePerDay, typeOfRoom.roomName);
                Uri Receipt = new Uri("Receipt.xaml", UriKind.Relative);
                this.NavigationService.Navigate(Receipt);
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Uri HotelsList = new Uri("HotelsList.xaml", UriKind.Relative);
            this.NavigationService.Navigate(HotelsList);
        }
    }
}