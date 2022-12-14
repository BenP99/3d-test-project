using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> spawners;
    public List<GameObject> shapes;
    public bool objectSpawned;
    private int randomisedIndex;
    private int shapeIndex;

    void Start() {
        objectSpawned = false;
    }

    void Update() {
        if(objectSpawned == false) {
            randomisedIndex = Random.Range(0,(spawners.Count - 1));
            shapeIndex = Random.Range(0,10);
            for(int i = 0; i < spawners.Count - 1; i++) {
                if(i == randomisedIndex && spawners[i].spawnerBlocked == false) {
                    if(shapeIndex <= 6) {
                        Instantiate(shapes[0], spawners[i].transform.position, Quaternion.identity);
                    } else if(shapeIndex > 6) {
                        Instantiate(shapes[1], spawners[i].transform.position, Quaternion.identity);
                    }
                    objectSpawned = true;
                }
            }
        }
    }
}
