using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieShare.Core;
using System.Data;

namespace CalorieShare.Data;
public class MealDto
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public float Prots { get; set; }
    public float Carbs { get; set; }
    public float Fats { get; set; }
    public float Weight { get; set; }
}

public class MealTable : Table
{
    public MealTable() : base("Meal")
    {
    }

    public void Add(string guid, MealDto meal)
    {
        var db = new Database();
        int id = this.AssosiatedSessionId(guid);


        db.Query(@"INSERT INTO MEAL(Calories,Protein,Carbs,Fat,
    HWeight, sessionID, Name) VALUES (@Calories, @Protein, @Carbs, @Fat, @HWeight, @sessionId, @Name)", "@Calories", meal.Calories, "@Protein", meal.Prots, "@Carbs", meal.Carbs, "@Fat", meal.Fats, "@HWeight", meal.Weight, "@sessionId", id, "@Name", meal.Name);
    }


    public IEnumerable<MealDto> AllMealsForSession(string guid)
    {

        int id = this.AssosiatedSessionId(guid);

        var db = new Database();
        DataTable mealsWhereSession = db.Query($"SELECT * FROM Meal WHERE sessionId = {id}");

        var dtos = new List<MealDto>();
        foreach (DataRow dr in mealsWhereSession.AsEnumerable())
        {
            dtos.Add(new MealDto()
            {
                Calories = dr.Field<int>("Calories"),
                Carbs = dr.Field<int>("Carbs"),
                Fats = dr.Field<int>("Fat"),
                Prots = dr.Field<int>("Protein"),
                Name = dr.Field<string>("Name"),
                Weight = dr.Field<int>("HWeight"),
            });
        }
        return dtos;
    }

    private int AssosiatedSessionId(string guid)
    {
        var db = new Database();
        DataTable session = db.Query("SELECT * FROM Heinrich_Session WHERE Guid = @guid", "@guid", guid);
        var theSession = session.AsEnumerable().FirstOrDefault();


        return theSession.Field<int>("Id");
    }



}
