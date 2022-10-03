using System.ComponentModel.DataAnnotations;

namespace Grocery.Domain.Enum{

public enum ItemType
{
    [Display(Name="Кисломолочные изделия")]
    Milk = 0,
    [Display(Name = "Хлебобулочные изделия")]
    Bakery = 1,
    [Display(Name = "Напитки")]
    Drinks = 2,
    [Display(Name = "Мясо")]
    Meat = 3,
    [Display(Name = "Сладости")]
    Sweets = 4
}}