using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawnerBlocked;
    public bool shapeSpawned;
    public bool cubeSpawned;
    public List<Spawner> nearSpawners;
    public GameController gc;

    void Start() {
        spawnerBlocked = false;
        shapeSpawned = false;
        cubeSpawned = false;
    }

    void Update() {
        if(CheckDefeat() && spawnerBlocked == true) {
            gc.gameDefeat = true;
        }
    }

    public bool CheckDefeat() {
        int cubeCount = 0;
        foreach(Spawner s in nearSpawners) {
            if(s.cubeSpawned == true) {
                cubeCount++;
            }
        }
        if(cubeCount == nearSpawners.Count) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")) {
            spawnerBlocked = true;
        }   
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")) {
            spawnerBlocked = false;
        }  
    }
}
