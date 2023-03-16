namespace App.DAL.QueryObjects.Filters;

public record PriceFilter(
    double Price,
    bool Operation);