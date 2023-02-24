using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ValueReference
{
    public Value valueBase;

    public Action onChange;
    public Action<Value> recalculate;

    public List<Value> dependent;

    internal void RecalculateDependencies()
    {
        if (dependent != null)
        {
            foreach (Value v in dependent)
            {
                recalculate?.Invoke(v);
            }
        }
    }

    public virtual string TEXT { get; internal set; }

    public abstract void Null();
}

public class ValueFloatReference : ValueReference
{
    public float value;

    public ValueFloatReference(Value _valueBase, float _value = 0)
    {
        valueBase = _valueBase;
        value = _value;
    }

    internal void Sum(float sum)
    {
        value += sum;
        onChange?.Invoke();
        base.RecalculateDependencies();
    }
    
    public override void Null()
    {
        value = 0;
        onChange?.Invoke();
        base.RecalculateDependencies();
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
        onChange?.Invoke();
        base.RecalculateDependencies();
    }

    public override void Null()
    {
        value = 0;
        onChange?.Invoke();
        base.RecalculateDependencies();
    }

    public override string TEXT
    {
        get
        {
            return valueBase.Name + " " + value;
        }
    }
}
