using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieShare.Core;
using CalorieShare.Data;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;
using System.Data;
using System.Linq; 
using System.Text.Json;

namespace CalorieShare.Api.Controllers;

public class MainController : BaseController
{
    [HttpPut]
    public GuidDto CreateSession()
    {
        var sesch = new Session();

        return new GuidDto { guid = sesch.HeinrichGuid() };
    }

    [HttpGet]
    public IEnumerable<MealDto> Search(string searchExpression)
    {
        Table nut = new Nutrition();
        DataTable dt = nut.All();
        var contains = dt.AsEnumerable().Where(p => p.Field<string>("Name").ToLower().Contains(searchExpression.ToLower()));
        var startsWith = dt.AsEnumerable().Where(p => p.Field<string>("Name").ToLower().Equals(searchExpression.ToLower()));

        List<MealDto> searchedMeals = new List<MealDto>();
        foreach (DataRow row in contains.Union(startsWith).ToList())
        {
            int calories = int.Parse(row.Field<string>("Calories"));
            string name = row.Field<string>("Name");
            float prots = float.Parse(row.Field<string>("Protein (g)"));
            float carbs = float.Parse(row.Field<string>("Carbohydrate (g)"));
            float fat = float.Parse(row.Field<string>("Fat (g)"));
            var rawWeight = row.Field<string>("Serving Weight 1 (g)");

            float weight = rawWeight == "NULL" ? 0 : float.Parse(rawWeight);

            var dto = new MealDto();
            dto.Calories = calories;
            dto.Carbs = carbs;
            dto.Fats = fat;
            dto.Name = name;
            dto.Prots = prots;
            dto.Weight = weight;


            searchedMeals.Add(dto);
        }


        return searchedMeals;
    }

    [HttpPut]
    public IActionResult AddMeal(string guid, MealDto meal)
    {
        MealTable table = new MealTable();

        table.Add(guid, meal);

        return Ok("Mahlzeit erfolgreich hinzugefügt");
    }

    [HttpGet]
    public IEnumerable<MealDto> AllMealsFor(string sessionGuid)
    {
        var table = new MealTable();
        return table.AllMealsForSession(sessionGuid);
    }

}


public class GuidDto
{
    public string guid { get; set; }
}