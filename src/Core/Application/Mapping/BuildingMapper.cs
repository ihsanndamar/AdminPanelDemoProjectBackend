using Application.InputModels;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class BuildingMapper
    {

        public static Building MapBuilding(BuildingInputModel buildingInputModel)
        {
            return new Building
            {
                Id = Guid.NewGuid(),
                BuildingType = buildingInputModel.BuildingType,
                BuildingCost = buildingInputModel.BuildingCost,
                ConstructionTime = buildingInputModel.ConstructionTime
            };
        }

        public static BuildingViewModel MapBuildingViewModel(Building building)
        {
            return new BuildingViewModel
            {
                Id = building.Id,
                BuildingType = building.BuildingType,
                BuildingCost = building.BuildingCost,
                ConstructionTime = building.ConstructionTime
            };
        }


    }
}
