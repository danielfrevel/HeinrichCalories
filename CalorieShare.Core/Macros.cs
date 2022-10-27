using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieShare.Core;

public interface IMacros
{
    public IWeight Protein { get; set; }
    public IWeight Carbs { get; set; }
    public IWeight Fats { get; set; }

}

public class Macros : IMacros
{
    public IWeight Protein { get; set; }
    public IWeight Carbs { get; set; }
    public IWeight Fats { get; set; }

    public Macros(float protein_gr, float carbs_gr, float fat_gr)
    {
        this.Protein = new Weight(protein_gr);

        this.Carbs = new Weight(carbs_gr);

        this.Fats = new Weight(fat_gr);
    }

}

