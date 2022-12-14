using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;

    void Start() {
        score = 0;
    }

    public void AddScore(int amount) {
        score = score + amount;
    }

    public void MinusScore(int amount) {
        score = score - amount;
    }
}
