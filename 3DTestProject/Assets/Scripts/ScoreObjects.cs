using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjects : MonoBehaviour
{
    public string shapeType;
    public ScoreController scoreController;
    public SpawnerController spawnController;

    void Start() {
        scoreController = GameObject.FindWithTag("ScoreController").GetComponent<ScoreController>();
        spawnController = GameObject.FindWithTag("SpawnerController").GetComponent<SpawnerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")) {
            if(this.gameObject.tag.Equals("Sphere")) {
                scoreController.AddScore(1);
            } else if(this.gameObject.tag.Equals("Capsule")) {
                scoreController.AddScore(2);
            }
        }

        spawnController.objectSpawned = false;
        Destroy(this.gameObject);
    }
}
