using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : MonoBehaviour {

    [SerializeField]
    private GameObject camera_;

    private Spawner ghost_spawner;
    private Spawner demon_spawner;
    private Spawner sorcerer_spawner;

    [SerializeField]
    Monster ghostPrototype;
    [SerializeField]
    Monster demonPrototype;
    [SerializeField]
    Monster sorcererPrototype;

    private int ghost_count = 0;
    private int demon_count = 0;
    private int sorcerer_count = 0;

    // Use this for initialization
    void Start () {
        camera_ = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (ghost_spawner == null) {
                ghost_spawner = new Spawner(ghostPrototype);

            }
            GameObject ghost = ghost_spawner.spawnMonster();
            ghost.name = "Ghost_" + ghost_count;
            ghost_count++;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (demon_spawner == null) {
                demon_spawner = new Spawner(demonPrototype);
            }
            GameObject demon = demon_spawner.spawnMonster();
            demon.name = "Demon_" + demon_count;
            demon_count++;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (sorcerer_spawner == null) {
                sorcerer_spawner = new Spawner(sorcererPrototype);
            }
            GameObject sorcerer = sorcerer_spawner.spawnMonster();
            sorcerer.name = "Sorcerer_" + sorcerer_count;
            sorcerer_count++;
        }
        
	}
}
