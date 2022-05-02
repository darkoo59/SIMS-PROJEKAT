﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

using Sims_Hospital_Zdravo.Repository;
using Sims_Hospital_Zdravo.Service;
using Sims_Hospital_Zdravo.Model;
using Model;
using Service;
namespace Sims_Hospital_Zdravo.Utils
{
    public  class AppointmentDoctorValidator
    {
        private AppointmentRepository appRepository;
        private RoomValidator roomValidator;
        private TimeSchedulerService timeSchedulerService;

        public AppointmentDoctorValidator(AppointmentRepository appointmentRepository,TimeSchedulerService timeSchedulerService,RoomService roomService)
        {
            this.appRepository = appointmentRepository;
            //this.roomValidator = roomValidator;
            this.timeSchedulerService = timeSchedulerService;
            roomValidator = new RoomValidator(roomService);
        }


        public  void ValidateAppointmentTimeTooLong(Appointment appointment)
        {
            DateTime start = appointment._Time.Start;
            DateTime end = appointment._Time.End;
            Console.WriteLine((end - start).TotalMinutes+"minutaa");
            if ((end - start).TotalMinutes > 30) 
            
                {
                    throw new Exception("Appoitment must be 30 minutes long");
                }
            
        }

        public void ValidateAppointmentRoomTaken(TimeInterval time, int id)
        {

            if(!(timeSchedulerService.IsRoomFreeInDateInterval(id,time)&& timeSchedulerService.IsRoomFreeInInterval(id, time)))
            
                throw new Exception("Appointment cant be scheduled.Choose another time and room");
            
            
            


        }

        public void ValidateDatePast(Appointment appointment)
        {
            DateTime date = appointment._Time.Start;
            if (date.CompareTo(DateTime.Now) < 0)
            { throw new Exception("Date has already passed."); }
            else if( appointment._Time.Start.TimeOfDay > appointment._Time.End.TimeOfDay)
            {
                throw new Exception("Date of start of appointment must be before date of end.");
            }
        }

        public void ValidateAppointment(Appointment appointment)
        {
            ValidateAppointmentTimeTooLong(appointment);
            ValidateAppointmentRoomTaken(appointment._Time, appointment._Id);
            ValidateDatePast(appointment);
            ValidateRoom(appointment);
            ValidateIfNull(appointment);
        }

        public void ValidateRoom(Appointment appointment)
        {
            Room room = appointment._Room;
            roomValidator.ValidateCreate(room);


        }
        public void ValidateIfNull(Appointment appointment)
        {
            if (appointment == null)
            { throw new Exception("All fields must be filled"); }
            else if (appointment._Patient == null)
            {
                throw new Exception("Patient field is empty");
            }
            else if (appointment._Time == null)
            {
                throw new Exception();
            }
            
        }


    }

}