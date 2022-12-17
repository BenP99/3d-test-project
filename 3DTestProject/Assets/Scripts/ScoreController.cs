using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;
    public int lvl;
    public int shapesInteracted;
    public string lastShapeCollected;

    void Start() {
        score = 0;
        shapesInteracted = 0;
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

    public void AddInteraction() {
        shapesInteracted++;
    }

    public void AddScore(int amount) {
        if((score + amount) < 400 && score < 400) {
            score = score + amount;
        } else {
            score = 400;
        }
    }

    public void MinusScore(int amount) {
        if((score - amount) > 0 && score > 0) {
            score = score - amount;
        } else {
            score = 0;
        }
    }
}
