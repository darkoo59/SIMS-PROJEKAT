/***********************************************************************
 * Module:  MedicalRecordController.cs
 * Author:  Darko
 * Purpose: Definition of the Class Controller.MedicalRecordController
 ***********************************************************************/

using Model;
using Service;
using Sims_Hospital_Zdravo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controller
{
   public class MedicalRecordController
   {

        public Service.MedicalRecordService medicalRecordService;
        public MedicalRecordValidator validator;
        public MedicalRecordController(MedicalRecordService recordService)
        {
            medicalRecordService = recordService;
            validator = new MedicalRecordValidator(medicalRecordService);
        }

        public void Create(MedicalRecord medicalRecord, Patient patient)
      {
            // TODO: implement
            medicalRecordService.Create(medicalRecord, patient);
        }

        public void ValidateInsert(String jmbg)
        {
            validator.InsertValidation(jmbg);
        }
      
      public MedicalRecord FindById(int id)
      {
         // TODO: implement
         return medicalRecordService.FindById(id);
      }

      public Patient FindPatientById(int id)
        {
            return medicalRecordService.FindPatientById(id);
        }


      public ref ObservableCollection<MedicalRecord> ReadAll()
      {
         // TODO: implement
         return ref medicalRecordService.ReadAll();
      }
      
      public void Update(MedicalRecord medicalRecord, Patient patient)
      {
            // TODO: implement
            medicalRecordService.Update(medicalRecord, patient);
      }

        public void ValidateUpdate(String jmbg)
        {
            validator.UpdateValidation(jmbg);
        }
      
      public void DeleteById(int id)
      {
            // TODO: implement
            medicalRecordService.DeleteById(id);
      }
      
      public void Delete(MedicalRecord medicalRecord)
      {
            // TODO: implement
            medicalRecordService.Delete(medicalRecord);
      }

        public int GenerateId()
        {
           return  medicalRecordService.GenerateId();
        }

        public int GeneratePatientId()
        {
            return medicalRecordService.GenreatePatientId();
        }


    }
}