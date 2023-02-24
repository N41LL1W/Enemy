using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Formula : ScriptableObject
{
    public abstract List<Value> GetReferences();
}

public abstract class FormulaInt : Formula
{
    public abstract int Calculate(StatsContainer stats);
}

public abstract class FormulaFloat: Formula
{
    public abstract float Calculate(StatsContainer stats);
}