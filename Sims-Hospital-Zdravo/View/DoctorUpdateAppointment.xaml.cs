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

namespace Sims_Hospital_Zdravo.View
{
    /// <summary>
    /// Interaction logic for DoctorUpdateAppointment.xaml
    /// </summary>
    public partial class DoctorUpdateAppointment : Window
    {
        public DoctorUpdateAppointment()
        {
            InitializeComponent();
        }

        

        /*private void UpdateAppo_Click(object sender, RoutedEventArgs e)
        {
            
           /* try
            {
                /*Appointment appointment = new Appointment(Int32.Parse(FloorTxt.Text), Int32.Parse(RoomIdTxt.Text), (RoomType)RoomTypeCmb.SelectedValue);
                roomController.Update(room);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        
    }
}
