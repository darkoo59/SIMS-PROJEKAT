﻿using Controller;
using Model;
using Sims_Hospital_Zdravo.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Sims_Hospital_Zdravo.View.Login
{
    /// <summary>
    /// Interaction logic for LoginMainWindow.xaml
    /// </summary>
    public partial class LoginMainWindow : Window
    {
        App app;
        public LoginMainWindow()
        {
            InitializeComponent();
            app = System.Windows.Application.Current as App;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountController accountController = app.accountController;
            String username = txtUsername.Text;
            String password = txtPassword.Password.ToString();
            User account = accountController.GetAccountByUsernameAndPassword(username, password);
            if (account != null)
            {
                switch (account._Role)
                {
                    case RoleType.MANAGER:
                        ManagerDashboard manaegerHome = new ManagerDashboard();
                        this.Close();
                        manaegerHome.Show();
                        break;
                    case RoleType.SECRETARY:
                        MedicalRecordController medicalController = app.recordController;
                        SecretaryHome secretaryHomeWindow = new SecretaryHome(medicalController);
                        this.Close();
                        secretaryHomeWindow.Show();
                        break;
                    case RoleType.DOCTOR:
                        DoctorAppointmentController doctorAppController = app.doctorAppointmentController;
                        RoomController roomControl = app.roomController;
                        DoctorCRUDWindow doctorCRUD = new DoctorCRUDWindow(doctorAppController, roomControl);
                        this.Close();
                        doctorCRUD.Show();
                        break;
                    case RoleType.PATIENT:
                        AppointmentPatientController appointmentPatientController = app.appointmentPatientController;
                        PatientWindow pw = new PatientWindow(appointmentPatientController);
                        this.Close();
                        pw.Show();
                        break;

                }
            }
            else
            {
                MessageBox.Show(" Incorrect Username/Password. Login Denied ", " Error! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
