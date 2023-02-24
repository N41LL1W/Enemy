using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formula/HP")]
public class HPFormula : FormulaInt
{
    //Vitality * 6 + Strength * 2 + 30
    public Value vitality;
    private int vit;
    public Value strength;
    private int str;
    
    public override int Calculate(StatsContainer stats)
    {
        stats.Get(vitality, out vit);
        stats.Get(strength, out str);
        return vit * 6 + str * 2 + 30; //ou você pode armazenar isso em uma variavel.
    }

    public override List<Value> GetReferences()
    {
        List<Value> values = new List<Value>();
        values.Add(vitality);
        values.Add(strength);
        return values;
    }
}
