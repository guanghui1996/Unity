using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Monster
{
    [SerializeField]
    private int health_;
    [SerializeField]
    private int speed_;

    public Demon(int health, int speed)
    {
        this.health_ = health;
        this.speed_ = speed;
    }

    public override GameObject Clone()
    {
        try
        {
            return Instantiate(this.gameObject, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(5, 15)), transform.rotation) as GameObject;
        }
        catch (System.Exception)
        {

            throw new System.NotImplementedException();
        }
    }
}
