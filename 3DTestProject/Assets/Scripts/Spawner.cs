using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawnerBlocked;

    void Start() {
        spawnerBlocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnerBlocked = true;
    }

    void OnTriggerExit(Collider other)
    {
        spawnerBlocked = false;
    }
}
