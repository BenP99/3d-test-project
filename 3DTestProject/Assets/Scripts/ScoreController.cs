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

    void FixedUpdate() {
        if(score < 100) {
            lvl = 1;
        } else if(score >= 100 && score < 200) {
            lvl = 2;
        } else if(score >= 200 && score < 300) {
            lvl = 3;
        }  else if(score >= 300) {
            lvl = 4;
        }
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
