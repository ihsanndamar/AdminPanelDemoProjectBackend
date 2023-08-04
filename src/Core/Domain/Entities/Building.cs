using Amazon.DynamoDBv2.DataModel;


namespace Domain.Entities
{   
    [DynamoDBTable("Buildings")]
    public class Building
    {
    
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }

        //relation with BuildingType
        [DynamoDBProperty("BuildingType")]
        public string BuildingType { get; set; }

        [DynamoDBProperty("BuildingCost")]
        public long BuildingCost { get; set; }
        
        [DynamoDBProperty("BuildingArea")]
        public int ConstructionTime { get; set; }

    
    }
}
