﻿using System.Collections.Generic;
using System.Linq;
using Sims_Hospital_Zdravo.Model;
using Sims_Hospital_Zdravo.Repository;

namespace Sims_Hospital_Zdravo.Service
{
    public class NotificationService
    {
        private NotificationRepository _notificationRepository;

        public NotificationService(NotificationRepository notificationRepository)
        {
            this._notificationRepository = notificationRepository;
        }

        public List<Notification> ReadAll()
        {
            return _notificationRepository.ReadAll();
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

        public int GenerateId()
        {
            List<Notification> appointments = _notificationRepository.ReadAll();
            List<int> ids = new List<int>(appointments.Select(x => x.Id));

            int id = 0;

            while (ids.Contains(id))
            {
                id++;
            }

            return id;
        }
    }
}