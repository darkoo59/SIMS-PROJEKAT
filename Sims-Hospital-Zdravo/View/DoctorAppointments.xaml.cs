﻿using Controller;
using System;
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
    /// Interaction logic for DoctorAppointments.xaml
    /// </summary>
    public partial class DoctorAppointments : Window
    {
        private DoctorAppointmentController doctorAppointmentController;
        public DoctorAppointments()
        {
            InitializeComponent();
        }
    }
}
