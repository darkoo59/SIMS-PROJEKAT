using System;
using System.Collections.Generic;
using System.Linq;
using Sims_Hospital_Zdravo.Interfaces;
using Sims_Hospital_Zdravo.Model;
using Sims_Hospital_Zdravo.Repository;

namespace Sims_Hospital_Zdravo.Model
{
    public class NotificationService
    {
        private INotificationRepository _notificationRepository;

        public NotificationService()
        {
            _notificationRepository = new NotificationRepository();
        }

        public List<Notification> FindAll()
        {
            return _notificationRepository.FindAll();
        }

        public Notification FindById(int id)
        {
            return _notificationRepository.FindById(id);
        }

        public void Delete(Notification notification)
        {
            _notificationRepository.Delete(notification);
        }

        public void DeleteById(int id)
        {
            _notificationRepository.DeleteById(id);
        }

        public void Create(Notification notification)
        {
            _notificationRepository.Create(notification);
        }

        public List<Notification> ReadAllManagerMedicineNotifications()
        {
            return _notificationRepository.ReadAllManagerMedicineNotifications();
        }

        public List<Notification> ReadAllSecretaryRequestForFreeDaysNotification()
        {
            return null;
        }

        public List<Notification> ReadAllDoctorMedicineNotifications(int doctorId)
        {
            return _notificationRepository.ReadAllDoctorMedicineNotifications(doctorId);
        }

        public List<Notification> ReadAllDoctorFreeDaysNotifications(int doctorId)
        {
            return _notificationRepository.ReadAllDoctorFreeDaysNotifications(doctorId);
        }

        public List<Notification> ReadAllManagerMeetingsNotifications(int managerId)
        {
            return _notificationRepository.ReadAllManagerMeetingsNotifications(managerId);
        }

        public List<Notification> ReadAllDoctorMeetingsNotifications(int doctorId)
        {
            return _notificationRepository.ReadAllDoctorMeetingsNotifications(doctorId);
        }

        public List<Notification> ReadAllSecretaryMeetingsNotifications(int secretaryId)
        {
            return _notificationRepository.ReadAllSecretaryMeetingsNotifications(secretaryId);
        }


        public int GenerateId()
        {
            List<Notification> notifications = _notificationRepository.FindAll();
            Console.WriteLine(notifications.Count);
            List<int> ids = new List<int>(notifications.Select(x => x.Id));

            int id = 0;

            while (ids.Contains(id))
            {
                id++;
            }

            return id;
        }
    }
}