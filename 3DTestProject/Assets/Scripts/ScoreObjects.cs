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
        if(other.gameObject.tag.Equals("Player") && !scoreController.lastShapeCollected.Equals(this.gameObject.tag)) {
            if(this.gameObject.tag.Equals("Sphere")) {
                scoreController.AddScore(1);
            } else if(this.gameObject.tag.Equals("Capsule")) {
                scoreController.AddScore(2);
            }
            scoreController.lastShapeCollected = this.gameObject.tag;
        } else {
            if(this.gameObject.tag.Equals("Sphere")) {
                scoreController.MinusScore(2);
            } else if(this.gameObject.tag.Equals("Capsule")) {
                scoreController.MinusScore(4);
            }
        }

        spawnController.RespawnShapes();
        Destroy(this.gameObject);
    }
}
