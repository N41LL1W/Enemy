using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ValueReference : ScriptableObject
{
    public Value valueBase;

    public Action onChange;
    
    public virtual string TEXT { get; internal set; }
}

public class ValueFloatReference : ValueReference
{
    public float value;

    public ValueFloatReference(Value _valueBase, float _value = 0f)
    {
        valueBase = _valueBase;
        value = _value;
    }

    internal void Sum(float sum)
    {
        value += sum;
        onChange();
    }
    public override string TEXT
    {
        get
        {
            return valueBase.Name + " " + value;
        }
    }
}

public class ValueIntReference : ValueReference
{
    public int value;
    
    public ValueIntReference(Value _valueBase, int _value = 0)
    {
        valueBase = _valueBase;
        value = _value;
    }
    
    internal void Sum(int sum)
    {
        value += sum;
        onChange();
    }
    public override string TEXT
    {
        get
        {
            return valueBase.Name + " " + value;
        }
    }
}
