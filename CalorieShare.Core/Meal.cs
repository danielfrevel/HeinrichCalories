namespace CalorieShare.Core;

/* 
Encapsulates einen Eintrag in der Tabelle 

 */
public interface IMeal
{
    public string? Name { get; set; }

    public ICalories Calories { get; set; }

    public IMacros? Macros { get; set; }

    public IWeight Weight { get; set; }
}

public class Meal : IMeal
{
    public string? Name { get; set; }
    public ICalories Calories { get; set; }
    public IMacros? Macros { get; set; }
    public IWeight? Weight { get; set; }

    public Meal(ICalories calories)
    {
        this.Calories = calories;

    }
    public Meal(string name, ICalories calories)
    {
        this.Name = name;
        this.Calories = calories;
    }

    public Meal AddMacros(IMacros macros)
    {
        this.Macros = macros;
        return this;
    }

    public Meal AddName(string name)
    {
        this.Name = name;
        return this;
    }
    public Meal AddWeight(IWeight weight)
    {
        this.Weight = weight;
        return this;
    }

}
