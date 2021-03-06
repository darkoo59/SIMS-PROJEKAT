using Sims_Hospital_Zdravo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace Sims_Hospital_Zdravo.Controller
{
    public class RenovationController
    {
        private RenovationService _renovationService;

        public RenovationController(RenovationService renovationService)
        {
            _renovationService = renovationService;
        }

        public void MakeRenovationAppointment(RenovationAppointment renovationAppointment)
        {
            _renovationService.MakeRenovationAppointment(renovationAppointment);
        }

        public void MakeAdvancedRenovationAppointment(AdvancedRenovationAppointment advancedRenovationAppointment)
        {
            _renovationService.MakeAdvancedRenovationAppointment(advancedRenovationAppointment);
        }

        public int GenerateId()
        {
            return _renovationService.GenerateId();
        }

        public List<TimeInterval> GetTakenDateIntervals(Room room)
        {
            return _renovationService.GetTakenDateIntervals(room);
        }

        public List<TimeInterval> GetTakenDateIntervals(List<Room> rooms)
        {
            return _renovationService.GetTakenDateIntervals(rooms);
        }

        public void FinishRenovationAppointment(int renovationId)
        {
            _renovationService.FinishRenovationAppointment(renovationId);
        }

        public void Create(RenovationAppointment renovation)
        {
            _renovationService.Create(renovation);
        }

        public void Update(RenovationAppointment renovation)
        {
            _renovationService.Update(renovation);
        }

        public void Delete(RenovationAppointment renovation)
        {
            _renovationService.Delete(renovation);
        }

        public List<RenovationAppointment> FindAll()
        {
            return _renovationService.FindAll();
        }

        public List<RenovationAppointment> FindByType(RenovationType type)
        {
            return _renovationService.FindByType(type);
        }
    }
}