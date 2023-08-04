using Amazon.DynamoDBv2.DataModel;


namespace Domain.Entities
{
    [DynamoDBTable("BuildingTypes")]
    public class BuildingType
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        
    }
}
