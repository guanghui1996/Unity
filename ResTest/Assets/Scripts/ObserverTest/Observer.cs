using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer
{
    protected string name_;

    public abstract void OnNotify();

    public abstract void Register(Subject subject);

    public abstract void UnRegister(Subject subject);

    public abstract string GetName();

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
