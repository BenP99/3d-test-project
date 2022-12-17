using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveData
{
    public float time; 
    public int score; 
    public int lvl; 
    public int shapesInteracted;

    public SaveData(float time, int score, int lvl, int shapesInteracted)
    {
        this.time = time;
        this.score = score;
        this.lvl = lvl;
        this.shapesInteracted = shapesInteracted;
    }
}
