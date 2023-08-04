using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InputModels
{
    public class BuildingInputModel
    {
        public Guid Id { get; set; }
        public string BuildingType { get; set; }
        public long BuildingCost { get; set; }
        public int ConstructionTime { get; set; }
    }
}
