using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIController : MonoBehaviour
{
    public ScoreController sc;
    public TimeCounter tc;
    public Text timeTakenText;
    public Text scoreText;
    public Text lvlText;
    public Text shapesText;

    public void SetValues()
    {
        var timeTaken = Mathf.Round(tc.time * 100.0f) * 0.01f;
        timeTakenText.text = "Time Taken: " + timeTaken.ToString();
        scoreText.text = "Score: " + sc.score.ToString();
        lvlText.text = "Level: " + sc.lvl.ToString();
        shapesText.text = "Shapes Interacted: " + sc.shapesInteracted.ToString();
    }
}
