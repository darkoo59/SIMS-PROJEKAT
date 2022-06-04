﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Controller;
using Model;
using Sims_Hospital_Zdravo.Controller;
using Sims_Hospital_Zdravo.Model;
using Sims_Hospital_Zdravo.ViewModel.Commands;

namespace Sims_Hospital_Zdravo.ViewModel
{
    public class ManagerDoctorSurveyModel : INotifyPropertyChanged
    {
        private App app;
        private SurveyController surveyController;
        private SurveyStatistics surveyStatistics;
        private DoctorAppointmentController doctorAppointmentController;
        private Doctor _selected;
        public List<QuestionStatistic> QuestionStatistics { get; set; }
        public string AverageMark { get; set; } = "Average Mark: ";
        public List<Doctor> Doctors { get; set; }

        public Doctor Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                UpdateSurveys();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ManagerDoctorSurveyModel()
        {
            app = Application.Current as App;
            doctorAppointmentController = app._doctorAppointmentController;
            surveyController = app._surveyController;
            Doctors = doctorAppointmentController.ReadAllDoctors();
        }

        private void UpdateSurveys()
        {
            try
            {
                surveyStatistics = surveyController.GetDoctorSurveyStatistics(Selected._Id);
                AverageMark = "Average Mark : " + surveyStatistics.AverageMark;
                OnPropertyChanged("AverageMark");
                QuestionStatistics = surveyStatistics.QuestionStatistics;
                OnPropertyChanged("QuestionStatistics");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}