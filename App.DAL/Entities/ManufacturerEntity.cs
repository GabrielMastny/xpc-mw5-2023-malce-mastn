namespace App.DAL.Entities;

public record ManufacturerEntity : EntityBase
{
    public required string _name { get; set; }
    public string _description { get; set; }
    public string _image { get; set; }
    public string _countryOfOrigin { get; set; }
    public ICollection<CommodityBase> _listOfCommodities { get; set; }
}