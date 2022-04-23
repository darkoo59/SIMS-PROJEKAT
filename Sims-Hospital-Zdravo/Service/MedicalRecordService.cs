/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
   public class MedicalRecordService
   {

        public Repository.MedicalRecordsRepository medicalRecordRepository;
        public PatientRepository patientRepository;

        public MedicalRecordService(MedicalRecordsRepository medicalRepo, PatientRepository patientRepo)
        {
            medicalRecordRepository = medicalRepo;
            patientRepository = patientRepo;
        }
      public void Create(MedicalRecord medicalRecord, Patient patient)
      {
            // TODO: implement
            medicalRecordRepository.Create(medicalRecord);
            patientRepository.Create(patient);
         return;
      }
      
      public MedicalRecord FindById(int id)
      {
            // TODO: implement
            return medicalRecordRepository.FindById(id);
      }


       public ref ObservableCollection<MedicalRecord> ReadAll()
      {
         // TODO: implement
         return ref medicalRecordRepository.ReadAll();
      }
      
      public void Update(MedicalRecord medicalRecord, Patient patient)
      {
            // TODO: implement
            patientRepository.Update(patient);
            medicalRecordRepository.Update(medicalRecord);
         return;
      }
      
      public void DeleteById(int id)
      {
            // TODO: implement
            medicalRecordRepository.DeleteById(id);
      }
      
      public void Delete(MedicalRecord medicalRecord)
      {
            // TODO: implement
            medicalRecordRepository.Delete(medicalRecord);
      }
      
        public Patient FindPatientById(int id)
        {
            return medicalRecordRepository.FindPatientById(id);
        }

   
   }
}