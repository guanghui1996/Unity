using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 搞不明白为什么arrayList.Remove(observer);会删除第一个值
/// </summary>
public class Subject
{
    private ArrayList arrayList = new ArrayList();
    private ArrayList names = new ArrayList();

    public void AddObserver(Observer observer) {
        if (names.Contains(observer.GetName())) {
            Debug.Log("队列中已经存在该物体");
            return;
        }
        names.Add(observer.GetName());
        arrayList.Add(observer);
    }

    public void RemoveObserver(Observer observer) {
        if (names.Contains(observer.GetName())) {
            names.Remove(observer.GetName());
            arrayList.Remove(observer);
            Debug.Log("删除的物体是" + observer.GetName());
        }
        else
        {
            Debug.Log("队列中无该观察者");
        }
        
    }

    public void Notify() {
        if (arrayList.Count == 0) {
            Debug.Log("observer count is already empty ");
        }

        Debug.Log("observer count is " + arrayList.Count);

        foreach (Observer observer in arrayList)
        {
            observer.OnNotify();
        }
    }

    public ArrayList ArrayList {
        get {
            return arrayList;
        }
    }

    
}
