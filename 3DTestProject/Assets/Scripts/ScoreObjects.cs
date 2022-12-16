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

    public int GetScore(string tag) {
        int score = 0;
        if(this.gameObject.tag.Equals("Sphere")) {
            if(scoreController.lvl == 1) {
                score = 1;
            } else if(scoreController.lvl == 2) {
                score = 10;
            } else if(scoreController.lvl == 3 || scoreController.lvl == 4) {
                score = 20;
            }
        } else if(this.gameObject.tag.Equals("Capsule")) {
            if(scoreController.lvl == 1) {
                score = 2;
            } else if(scoreController.lvl == 2) {
                score = 12;
            } else if(scoreController.lvl == 3 || scoreController.lvl == 4) {
                score = 22;
            }
        }
        return score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") && !scoreController.lastShapeCollected.Equals(this.gameObject.tag)) {
            if(this.gameObject.tag.Equals("Sphere")) {
                scoreController.AddScore(GetScore("Sphere"));
            } else if(this.gameObject.tag.Equals("Capsule")) {
                scoreController.AddScore(GetScore("Capsule"));
            }
            scoreController.lastShapeCollected = this.gameObject.tag;
        } else {
            if(this.gameObject.tag.Equals("Sphere")) {
                scoreController.MinusScore(GetScore("Sphere") * 2);
            } else if(this.gameObject.tag.Equals("Capsule")) {
                scoreController.MinusScore(GetScore("Capsule") * 2);
            }
        }

        scoreController.AddInteraction();
        spawnController.RespawnShapes();
        Destroy(this.gameObject);
    }
}
