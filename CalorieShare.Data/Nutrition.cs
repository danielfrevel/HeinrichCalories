using System;
using System.Collections.Generic;
using System.Data;
using CalorieShare.Core;

namespace CalorieShare.Data;

public class Nutrition : Table
{
    public Nutrition() : base("Nutrition_Base")
    {
    }

    public Meal Meal(string name)
    {
        DataTable allMeals = this.All();
        var foundMeal = allMeals.AsEnumerable().Where(p => p.Field<string>("Name") == name).FirstOrDefault();

        if (foundMeal is null) throw new Exception($"{name} nicht gefunden");

        return new Meal(name, new Calories(foundMeal.Field<int>("Calories")));
    }
}
