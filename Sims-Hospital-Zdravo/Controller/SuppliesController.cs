using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Sims_Hospital_Zdravo.Model;

namespace Sims_Hospital_Zdravo.Controller
{
    public class SuppliesController
    {
        private SuppliesService _suppliesService;

        public SuppliesController()
        {
            this._suppliesService = new SuppliesService();
        }

        public void Update(SuppliesAcquisition suppliesAcquisition)
        {
            _suppliesService.Update(suppliesAcquisition);
        }
        
        
        public List<RoomEquipment> FindAllEquipment()
        {
            return this._suppliesService.FindAllEquipment();
        }
        
        public List<SuppliesAcquisition> ReadAllSuppliesAcquisitions()
        {
            return this._suppliesService.ReadAllSuppliesAcquisitions();
        }

        public void FinishSuppliesAcquisition(int acquisitionId)
        {
            this._suppliesService.FinishSuppliesAcquisition(acquisitionId);
        }

        public Equipment CreateNewEquipment(string name)
        {
            return _suppliesService.CreateNewEquipment(name);
        }

        public void Create(SuppliesAcquisition suppliesAcquisition)
        {
            _suppliesService.Create(suppliesAcquisition);
        }
    }
}