﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Controller;
using Repository;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sims_Hospital_Zdravo.View
{
    /// <summary>
    /// Interaction logic for DoctorCreateAppointment.xaml
    /// </summary>
    public partial class DoctorCreateAppointment : Window
    {
        private DoctorAppointmentController docAppController;
        private RoomController roomController;
        private int id;
        public DoctorCreateAppointment(DoctorAppointmentController docController,RoomController roomControl)
        {
            InitializeComponent();
            this.DataContext = this;
            this.docAppController = docController;
            this.roomController = roomControl;

        }
        private Patient pat;
        public Patient Pat
        {
            get { return pat; }
            set { pat = value; }
        }
        public Patient PatientSelected()
        {
            string[] patient = PatientTxt.Text.Split(' ');
            Console.WriteLine(patient);
            foreach (Patient pat in docAppController.getPatients())
            {
                if (pat._Name.Equals(patient[0]) && pat._Surname.Equals(patient[1]))
                {
                    Pat = pat;
                    

                }
            }
            return Pat;
        }
        Random rnd = new Random();
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //String date = dateTxt.Text;
            ComboBoxItem cbItem = cbTime.SelectedItem as ComboBoxItem;
            
            
                string t = cbItem.Content.ToString();
                string d = DatePick.Text;
                var dt = DateTime.Parse(d + " " + t);
                
            
            int numOfRoom = Int32.Parse(RoomTxt.Text);
            Room room = this.roomController.FindById(numOfRoom);
            Doctor doc = this.docAppController.getDoctor(2);
            Patient pat = PatientSelected();
            Appointment app = new Appointment(room,doc,pat,dt, 5);
            docAppController.Create(app);
            Close();

        }

        
    }
}
