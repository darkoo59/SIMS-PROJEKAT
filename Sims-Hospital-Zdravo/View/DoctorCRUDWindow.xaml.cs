using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Sims_Hospital_Zdravo.Interfaces;

namespace Sims_Hospital_Zdravo.View
{
    /// <summary>
    /// Interaction logic for DoctorCRUDWindow.xaml
    /// </summary>
    public partial class DoctorCRUDWindow : Page, IUpdateFilesObserver
    {
        public List<Appointment> DoctorAppointments;
        private DoctorAppointmentController doctorAppController;
        public RoomController roomController;
        private Appointment app;
        private App application;
        private int doctorId;
        public Appointment _App
        {
            get { return this.app; }
            set { this.app = value; }
        }

        public DoctorCRUDWindow(DoctorAppointmentController doctorAppointmentController,int id)
        {
           
            InitializeComponent();
            this.DataContext = this;
            this.doctorId = id;
            this.roomController = new RoomController();
            this.doctorAppController = doctorAppointmentController;
            DoctorAppointments = doctorAppController.ReadAll(doctorId);
            
            //this.DataContext = DoctorAppointments;
            dataGridDoctorApps.AutoGenerateColumns = false;

            DataGridTextColumn data_column = new DataGridTextColumn();
            data_column.Header = "Start Time";
            data_column.Binding = new Binding("Time.Start");
            dataGridDoctorApps.Columns.Add(data_column);
            data_column = new DataGridTextColumn();
            data_column.Header = "Start Time";
            data_column.Binding = new Binding("Time.End");

            dataGridDoctorApps.Columns.Add(data_column);
            data_column = new DataGridTextColumn();
            data_column.Header = "Patient Name";
            data_column.Binding = new Binding("Patient.Name");
            dataGridDoctorApps.Columns.Add(data_column);
            data_column = new DataGridTextColumn();
            data_column.Header = "Patient Surname";
            data_column.Binding = new Binding("Patient.Surname");
            dataGridDoctorApps.Columns.Add(data_column);
            

            data_column = new DataGridTextColumn();
            data_column.Header = "Type";
            data_column.Binding = new Binding("Type ");
            dataGridDoctorApps.Columns.Add(data_column);


            dataGridDoctorApps.ItemsSource = DoctorAppointments;
            dataGridDoctorApps.Items.Refresh();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure you want to delete this appointment?", "Delete", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    doctorAppController.DeleteByID((Appointment)dataGridDoctorApps.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editAppointment_Click(object sender, RoutedEventArgs e)
        {
            app = dataGridDoctorApps.SelectedValue as Appointment;
            if (app != null)
            {
                DoctorUpdateAppointment editAppointment = new DoctorUpdateAppointment(doctorAppController, app, roomController,doctorId) { DataContext = dataGridDoctorApps.SelectedItem };

                editAppointment.Show();
            }
            else
            {
                MessageBox.Show("Chose appointment you want to edit.");
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorCreateAppointment addAppointment = new DoctorCreateAppointment(doctorAppController, roomController);
            addAppointment.AddObserver(this);
            addAppointment.Show();
        }

        public void NotifyUpdated()
        {
            DoctorAppointments = doctorAppController.ReadAll(doctorId);
            dataGridDoctorApps.ItemsSource = DoctorAppointments;
        }
    }
}