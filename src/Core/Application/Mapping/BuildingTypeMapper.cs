using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class BuildingTypeMapper
    {
        public static BuildingType MapBuildingType(string buildingTypeName)
        {
            return new BuildingType
            {
                Id = Guid.NewGuid(),
                Name = buildingTypeName
            };
        }

        public static BuildingTypeViewModel MapBuildingTypeViewModel(BuildingType buildingType)
        {
            return new BuildingTypeViewModel
            {
                Name = buildingType.Name
            };
        }
    }
}
