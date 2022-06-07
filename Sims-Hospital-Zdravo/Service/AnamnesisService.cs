﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Sims_Hospital_Zdravo.Model;
using Sims_Hospital_Zdravo.Repository;
using Model;

namespace Sims_Hospital_Zdravo.Model
{
    public class AnamnesisService
    {
        private AnamnesisRepository _anamnesisRepository;

        public AnamnesisService()
        {
            this._anamnesisRepository = new AnamnesisRepository(); 
        }

        public void Create(Anamnesis anamnesis)
        {
            _anamnesisRepository.Create (anamnesis); 
        }

        public void Update(Anamnesis anamnesis)
        {
            _anamnesisRepository.Update (anamnesis);
        }

        public  List<Anamnesis> FindAll()
        {
            return  _anamnesisRepository.FindAll();
        }

        public ObservableCollection<Anamnesis> findAnamnesisByDoctor(int id)
        {
            return _anamnesisRepository.FindAnamnesisByDoctor(id);
        }
        //public Anamnesis FindAnamnesisByAppointment(Appointment appointment)
        //{
        //    return _anamnesisRepository.FindAnamnesisByDoctor(id);
        //}
        public ObservableCollection<Anamnesis> FindAnamnesisByPatient(MedicalRecord medicalRecord)
        {
            return _anamnesisRepository.FindAnamesisByPatient (medicalRecord);
        }
    }
}
