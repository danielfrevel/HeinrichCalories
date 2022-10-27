using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieShare.Core;

public interface IWeight
{
    public float grams { get; set; }
}
public class Weight : IWeight
{
    public float grams { get; set; }

    public Weight(float grams)
    {
        this.grams = grams;
    }

    public float gramValue()
    {
        return this.grams;
    }


}
