using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;
    public int lvl;
    public string lastShapeCollected;

    void Start() {
        score = 0;
        lvl = 1;
        lastShapeCollected = "";
    }

    public void AddScore(int amount) {
        score = score + amount;
    }

    public void MinusScore(int amount) {
        if(score > 0) {
            score = score - amount;
        } else {
            score = 0;
        }
    }
}
