﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Controller;
using Model;
using Sims_Hospital_Zdravo.Controller;
using Sims_Hospital_Zdravo.Interfaces;

namespace Sims_Hospital_Zdravo.View.Secretary.Examination
{
    /// <summary>
    /// Interaction logic for ExaminationWindow.xaml
    /// </summary>
    public partial class ExaminationWindow : Window, IUpdateFilesObserver
    {
        private SecretaryAppointmentController secretaryAppointmentController;
        public ObservableCollection<Appointment> appointments;
        private App app;
        public ExaminationWindow(SecretaryAppointmentController controller)
        {
            app = Application.Current as App;
            InitializeComponent();
            this.DataContext = this;
            this.secretaryAppointmentController = controller;
            appointmentsDatePicker.SelectedDate = DateTime.Today;
            UpdateGridView();

            appointments = secretaryAppointmentController.ReadAllAppointmentsForDate(DateTime.Parse(appointmentsDatePicker.SelectedDate.ToString()));
            GridAppointments.ItemsSource = appointments;
        }

        private void appDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GridAppointments.ItemsSource = null;
            NotifyUpdated();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure you want to cancel this appointment?", "Cancel appointment", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    secretaryAppointmentController.Delete((Appointment)GridAppointments.SelectedItem);
                    NotifyUpdated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reschedule_Click(object sender, RoutedEventArgs e)
        {
            if (GridAppointments.SelectedItem != null)
            {
                RescheduleExaminationWindow rescheduleWindow = new RescheduleExaminationWindow((Appointment)GridAppointments.SelectedValue, secretaryAppointmentController) { DataContext = GridAppointments.SelectedItem };
                rescheduleWindow.Show();
            }
            else
                MessageBox.Show("Appointment isn't selected", "Please select appointment", MessageBoxButton.OK);
        }

        public void NotifyUpdated()
        {
            appointments = secretaryAppointmentController.ReadAllAppointmentsForDate(DateTime.Parse(appointmentsDatePicker.SelectedDate.ToString()));
            GridAppointments.ItemsSource = appointments;
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            NewAppointmentChooseDate chooseDate = new NewAppointmentChooseDate();
            chooseDate.Show();
        }

        private void UpdateGridView()
        {
            GridAppointments.AutoGenerateColumns = false;
            GridAppointments.CanUserSortColumns = false;
            DataGridTextColumn dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Doctor name";
            dataColumn.Binding = new Binding("_Doctor._Name");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Doctor surname";
            dataColumn.Binding = new Binding("_Doctor._Surname");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Patient name";
            dataColumn.Binding = new Binding("_Patient._Name");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Patient surname";
            dataColumn.Binding = new Binding("_Patient._Surname");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Room type";
            dataColumn.Binding = new Binding("_Room.Type");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "Start at";
            dataColumn.Binding = new Binding("_Time.Start");
            GridAppointments.Columns.Add(dataColumn);
            dataColumn = new DataGridTextColumn();
            dataColumn.Header = "End at";
            dataColumn.Binding = new Binding("_Time.End");
            GridAppointments.Columns.Add(dataColumn);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            NotifyUpdated();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && this.IsFocused == true)
                this.DragMove();
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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Emergency_Click(object sender, RoutedEventArgs e)
        {
            EmergencyExaminationWindow window = new EmergencyExaminationWindow();
            window.Show();
            this.Close();
        }

        private void Home_Click(object sender, MouseButtonEventArgs e)
        {
            SecretaryHome window = new SecretaryHome();
            window.Show();
            this.Close();
        }

        private void MedicalRecord_Click(object sender, MouseButtonEventArgs e)
        {
            SecretaryWindow window = new SecretaryWindow(app._recordController);
            window.Show();
            this.Close();
        }
    }
}
