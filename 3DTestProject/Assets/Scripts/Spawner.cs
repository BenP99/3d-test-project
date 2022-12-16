using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawnerBlocked;
    public bool shapeSpawned;

    void Start() {
        spawnerBlocked = false;
        shapeSpawned = false;
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
