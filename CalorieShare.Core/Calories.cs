using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieShare.Core;
public interface ICalories
{
    public int Kcal { get; set; }
}

public class Calories : ICalories
{
    public int Kcal { get; set; }
    public Calories(int kcal)
    {
        this.Kcal = kcal;
    }
}