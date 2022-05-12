﻿using System.Collections.Generic;
using Model;
using Sims_Hospital_Zdravo.Interfaces;
using Sims_Hospital_Zdravo.Utils.Filters;

namespace Sims_Hospital_Zdravo.Utils.FilterPipelines
{
    public class RoomEquipmentFilterPipeline : IFilterPipeline<RoomEquipment>
    {
        protected RoomEquipmentFilterPipeline()
        {
            filters = new List<IFilter<RoomEquipment>>();
        }

        public override List<RoomEquipment> FilterAll(List<RoomEquipment> objects)
        {
            List<RoomEquipment> filteredEquipment = new List<RoomEquipment>(objects);
            foreach (var filter in filters)
            {
                filteredEquipment = filter.Filter(filteredEquipment);
            }

            return filteredEquipment;
        }

        public override IFilterPipeline<RoomEquipment> AddFilter(IFilter<RoomEquipment> filter)
        {
            filters.Add(filter);
            return this;
        }

        public static IFilterPipeline<RoomEquipment> CreateEquipmentFilterPipeline(bool showStatic, bool showConsumable)
        {
            if (showStatic && showConsumable)
            {
                return new RoomEquipmentFilterPipeline();
            }

            if (showStatic)
            {
                return (new RoomEquipmentFilterPipeline())
                    .AddFilter(new RoomEquipmentTypeFilter(EquipmentType.Static));
            }

            if (showConsumable)
            {
                return (new RoomEquipmentFilterPipeline())
                    .AddFilter(new RoomEquipmentTypeFilter(EquipmentType.Consumable));
            }

            return (new RoomEquipmentFilterPipeline())
                .AddFilter(new RoomEquipmentTypeFilter(EquipmentType.Consumable))
                .AddFilter(new RoomEquipmentTypeFilter(EquipmentType.Static));
        }
    }
}