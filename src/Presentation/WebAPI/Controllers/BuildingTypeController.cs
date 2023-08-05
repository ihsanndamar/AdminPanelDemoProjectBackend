using Amazon.DynamoDBv2.DataModel;
using Application.Mapping;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingTypeController : ControllerBase
    {
        readonly IDynamoDBContext _dynamoDBContext;

        public BuildingTypeController(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<BuildingType> buildingTypes = await _dynamoDBContext.ScanAsync<BuildingType>(default).GetRemainingAsync();
            var buildingTypeViewModels = buildingTypes.Select(bt => BuildingTypeMapper.MapBuildingTypeViewModel(bt)); 
            return Ok(buildingTypeViewModels);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string BuildingTypeName)
        {
            var buildingType = BuildingTypeMapper.MapBuildingType(BuildingTypeName);
            _dynamoDBContext.SaveAsync(buildingType);
            return Ok("Created Successfully");

        }
    }
}
