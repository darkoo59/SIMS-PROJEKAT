﻿using System;
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
using Sims_Hospital_Zdravo.View.Secretary.Examination;

namespace Sims_Hospital_Zdravo.View.Secretary.Supplies
{
    /// <summary>
    /// Interaction logic for SuppliesHome.xaml
    /// </summary>
    public partial class SuppliesHome : Window
    {
        private App app;
        public SuppliesHome()
        {
            app = Application.Current as App;
            InitializeComponent();
        }
        
        
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if(TgButton.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_profile.Visibility = Visibility.Collapsed;
                tt_about.Visibility = Visibility.Collapsed;
                tt_meetings.Visibility = Visibility.Collapsed;
                tt_accounts.Visibility = Visibility.Collapsed;
                tt_equipment.Visibility = Visibility.Collapsed;
                tt_appointments.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_medical_records.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_sign_out.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_profile.Visibility = Visibility.Visible;
                tt_about.Visibility = Visibility.Visible;
                tt_meetings.Visibility = Visibility.Visible;
                tt_accounts.Visibility = Visibility.Visible;
                tt_equipment.Visibility = Visibility.Visible;
                tt_appointments.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_medical_records.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_sign_out.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && this.IsFocused == true)
                this.DragMove();
        }
        
        private void MedicalRecord_Click(object sender, MouseButtonEventArgs e)
        {
            SecretaryWindow window = new SecretaryWindow(app._recordController);
            window.Show();
            this.Close();
        }

        private void Appointment_Click(object sender, MouseButtonEventArgs e)
        {
            ExaminationWindow window = new ExaminationWindow(app._secretaryAppointmentController);
            window.Show();
            this.Close();
        }

        private void SendRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}