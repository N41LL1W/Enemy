using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formula : ScriptableObject
{
    
}

public abstract class FormulaInt : Formula
{
    public abstract int Calculate(StatsContainer stats);
}

public abstract class FormulaFloat: Formula
{
    public abstract float Calculate(StatsContainer stats);
}