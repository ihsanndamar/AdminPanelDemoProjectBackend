using Amazon.DynamoDBv2.DataModel;
using Application.InputModels;
using Application.Mapping;
using Application.Validators;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        readonly IDynamoDBContext _dynamoDBContext;

        public BuildingController(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Building> buildings = await _dynamoDBContext.ScanAsync<Building>(default).GetRemainingAsync();
            var buildingViewModels = buildings.Select(b => BuildingMapper.MapBuildingViewModel(b));
            return Ok(buildings);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BuildingInputModel buildingInputModel)
        {
            var building = BuildingMapper.MapBuilding(buildingInputModel);

            //check validation
            var buildingValidator = new BuildingValidator();
            var validationResult = buildingValidator.Validate(building);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _dynamoDBContext.SaveAsync(building);
            return Ok("Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BuildingInputModel buildingInputModel)
        {
            var building = await _dynamoDBContext.LoadAsync<Building>(buildingInputModel.Id);
            if (building == null)
            {
                return NotFound("Building not found");
            }
            building = BuildingMapper.MapBuilding(buildingInputModel);
            await _dynamoDBContext.SaveAsync(building);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _dynamoDBContext.DeleteAsync<Building>(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var building = await _dynamoDBContext.LoadAsync<Building>(id);
            if (building == null)
            {
                return NotFound("Building not found");
            }
            var buildingViewModel = BuildingMapper.MapBuildingViewModel(building);
            return Ok(buildingViewModel);
        }
    }
}
