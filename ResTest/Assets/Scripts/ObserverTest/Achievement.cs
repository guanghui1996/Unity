using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : Observer
{
    public Achievement(string name) {
        name_ = name;
    }

    public override void OnNotify()
    {
        Debug.Log("There is Achievement " + this.name_);
    }

    public override void Register(Subject subject)
    {
        subject.AddObserver(this);
    }

    public override void UnRegister(Subject subject)
    {
        subject.RemoveObserver(this);
    }

    public override string GetName()
    {
        return name_;
    }

}
