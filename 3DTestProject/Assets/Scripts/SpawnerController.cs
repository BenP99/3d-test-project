using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> spawners;
    public List<GameObject> shapes;
    public GameObject cube;
    public bool spawnShape;
    public int spawnCount;
    public float time;
    public List<GameObject> spawnedShapes;
    public bool firstShapeSpawned;
    public ScoreController sc;

    void Start() {
        spawnShape = true;
        firstShapeSpawned = false;
        spawnCount = 2;
        spawnedShapes = new List<GameObject>();
        StartCoroutine(SpawnCube());
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

        if(sc.lvl == 1) {
            time = 14;
        } else if(sc.lvl == 2) {
            time = 12;
        } else if(sc.lvl == 3) {
            time = 10;
        } else if(sc.lvl == 4) {
            time = 8;
        }
    }

    public Spawner FindValidSpawner() {
        List<Spawner> validSpawners = new List<Spawner>();

        foreach(Spawner sp in spawners) {
            if(sp.spawnerBlocked == false && sp.shapeSpawned == false && sp.cubeSpawned == false) {
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

    public IEnumerator SpawnCube() {
        while(true) {
            Spawner sp = FindValidSpawner();
            GameObject s = Instantiate(cube, sp.gameObject.transform.position, Quaternion.identity);
            sp.cubeSpawned = true;
            yield return new WaitForSeconds(time);
        }
    }
}
