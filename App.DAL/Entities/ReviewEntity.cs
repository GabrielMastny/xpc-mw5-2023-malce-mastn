namespace App.DAL.Entities;

public record ReviewEntity : EntityBase
{
    public required int _stars { get; set; }
    public string _title { get; set; }
    public string _description { get; set; }
}