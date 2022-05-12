﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sims_Hospital_Zdravo.Controller;
using Sims_Hospital_Zdravo.Interfaces;

namespace Sims_Hospital_Zdravo.View.Secretary.Examination
{
    /// <summary>
    /// Interaction logic for RescheduleExaminationWindow.xaml
    /// </summary>
    public partial class RescheduleExaminationWindow : Window
    {
        private Appointment selectedAppointment;
        private SecretaryAppointmentController secretaryAppointmentController;
        private App app;
        public RescheduleExaminationWindow(Appointment appointment, SecretaryAppointmentController controller)
        {
            app = Application.Current as App;
            InitializeComponent();
            this.DataContext = this;
            this.selectedAppointment = appointment;
            this.secretaryAppointmentController = controller;
            startDatePicker.SelectedDate = appointment._Time.Start;
            endDatePicker.SelectedDate = appointment._Time.End;
            txtStartTime.Text = appointment._Time.Start.TimeOfDay.ToString();
            txtEndTime.Text = appointment._Time.End.TimeOfDay.ToString();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string startString = startDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
                DateTime startDate = DateTime.Parse(startString);
                string[] startTime = txtStartTime.Text.Split(':');
                startDate = startDate.AddHours(Int32.Parse(startTime[0]));
                startDate = startDate.AddMinutes(Int32.Parse(startTime[1]));

                string endString = endDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
                DateTime endDate = DateTime.Parse(endString);
                string[] endTime = txtEndTime.Text.Split(':');
                endDate = endDate.AddHours(Int32.Parse(endTime[0]));
                endDate = endDate.AddMinutes(Int32.Parse(endTime[1]));
                TimeInterval time = new TimeInterval(startDate, endDate);
                Appointment app = new Appointment(selectedAppointment._Room, selectedAppointment._Doctor, selectedAppointment._Patient, time, selectedAppointment._Type);
                app._Id = selectedAppointment._Id;

                secretaryAppointmentController.Update(app);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TgButton.IsChecked == true)
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && this.IsFocused == true)
                this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Home_Click(object sender, MouseButtonEventArgs e)
        {
            SecretaryHome window = new SecretaryHome();
            window.Show();
            this.Close();
        }

        private void Appointment_Click(object sender, MouseButtonEventArgs e)
        {
            ExaminationWindow window = new ExaminationWindow(app._secretaryAppointmentController);
            window.Show();
            this.Close();
        }
    }
}
