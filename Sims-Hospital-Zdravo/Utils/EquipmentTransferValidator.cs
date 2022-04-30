﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;
using Repository;

namespace Utils
{
    class EquipmentTransferValidator
    {
        private RoomRepository _roomRepo;
        private TimeSchedulerService _timeSchedulerService;


        public EquipmentTransferValidator(RoomRepository roomRepo, TimeSchedulerService timeSchedulerService)
        {
            this._roomRepo = roomRepo;
            this._timeSchedulerService = timeSchedulerService;
        }


        private void HasEnoughEquipment(int roomId, int quantity, int equipmentId)
        {
            Room room = _roomRepo.FindById(roomId);
            foreach (RoomEquipment re in room.RoomEquipment)
            {
                if (re.Equipment.Id != equipmentId) continue;
                if (re.Quantity < quantity)
                {
                    throw new Exception("Not enough equipment for transfer!");
                }
            }
        }

        private void RoomExists(int roomId)
        {
            Room room = _roomRepo.FindById(roomId);
            if (room == null)
                throw new Exception("Room number " + roomId + " does not exist!");
        }


        private void ValidateRoomTaken(int roomId, TimeInterval ti)
        {
            if (!_timeSchedulerService.IsRoomFreeInInterval(roomId, ti))
            {
                throw new Exception("Room " + roomId + " is not free in given interval!");
            }
        }


        public void ValidateTransferFromRoom(int fromRoomId, int toRoomId, int equipmentId, int quantity,
            TimeInterval ti)
        {
            RoomExists(fromRoomId);
            RoomExists(toRoomId);
            HasEnoughEquipment(fromRoomId, quantity, equipmentId);
            ValidateRoomTaken(fromRoomId, ti);
            ValidateRoomTaken(toRoomId, ti);
        }
    }
}