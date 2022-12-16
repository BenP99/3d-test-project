using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> spawners;
    public List<GameObject> shapes;
    public bool spawnShape;
    public int spawnCount;
    public List<GameObject> spawnedShapes;
    public bool firstShapeSpawned;

    void Start() {
        spawnShape = true;
        firstShapeSpawned = false;
        spawnCount = 2;
        spawnedShapes = new List<GameObject>();
    }

    void Update() {
        if(spawnShape == true) {
            for(int i = 0; i < spawnCount; i++) {
                Spawner sp = FindValidSpawner();
                GameObject shape = new GameObject();

                if(firstShapeSpawned == false) {
                    shape = shapes.Find(item => item.tag.Equals("Sphere"));
                    firstShapeSpawned = true;
                } else {
                    shape = shapes.Find(item => item.tag.Equals("Capsule"));
                }

                GameObject s = Instantiate(shape, sp.gameObject.transform.position, Quaternion.identity);
                spawnedShapes.Add(s);
                sp.shapeSpawned = true;
            }
            spawnShape = false;
        }
    }

    public Spawner FindValidSpawner() {
        List<Spawner> validSpawners = new List<Spawner>();

        foreach(Spawner sp in spawners) {
            if(spawnShape == true && sp.spawnerBlocked == false && sp.shapeSpawned == false) {
                validSpawners.Add(sp);
            }
        }

        return validSpawners[Random.Range(0, validSpawners.Count)];
    }

    public void RespawnShapes() {
        foreach(Spawner s in spawners) {
            if(s.shapeSpawned == true) {
                s.shapeSpawned = false;
            }
        }

        for(int i = 0; i < spawnedShapes.Count; i++) {
            Destroy(spawnedShapes[i].gameObject);
        }

        spawnedShapes.Clear();
        firstShapeSpawned = false;
        spawnShape = true;
    }
}
