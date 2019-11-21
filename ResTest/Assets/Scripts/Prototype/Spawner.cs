using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Object {

    private Monster prototype_;

    public Spawner(Monster prototype) {
        this.prototype_ = prototype;
    }

    public GameObject spawnMonster() {
        return prototype_.Clone();
    }
}
