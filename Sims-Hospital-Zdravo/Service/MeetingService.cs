using Model;
using Repository;
using Sims_Hospital_Zdravo.Model;
using Sims_Hospital_Zdravo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sims_Hospital_Zdravo.Interfaces;
using Sims_Hospital_Zdravo.Utils;

namespace Sims_Hospital_Zdravo.Service
{
    public class MeetingService
    {
        private IRoomRepository _roomRepository;
        private IAccountRepository _accountRepository;
        private IMeetingRepository _meetingRepository;
        private INotificationRepository _notificationRepository;
        private MeetingValidator _meetingValidator;
        private NotificationService _notificationService;

        public MeetingService()
        {
            _roomRepository = new RoomRepository();
            _accountRepository = new AccountRepository();
            _meetingRepository = new MeetingRepository();
            _notificationRepository = new NotificationRepository();
            _meetingValidator = new MeetingValidator();
            _notificationService = new NotificationService();
        }

        public void Create(Meeting meeting)
        {
            _meetingValidator.ValidateMeeting(meeting);
            _meetingRepository.Create(meeting);
        }

        public void CreateMeetingWithNotifying(Meeting meeting, List<Notification> notifications)
        {
            Create(meeting);
            foreach (Notification notification in notifications)
            {
                notification.Id = _notificationService.GenerateId();
                _notificationRepository.Create(notification);
            }
        }

        public List<Room> ReadAllRooms()
        {
            return _roomRepository.FindAll().ToList();
        }

        public List<User> ReadAllPotentionalAttendees()
        {
            return (from User user in _accountRepository.FindAll()
                where user.Role != RoleType.PATIENT
                select user).ToList();
        }
    }
}