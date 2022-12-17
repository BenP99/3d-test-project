using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public SaveController save;
    public Text timeTakenText;
    public Text scoreText;
    public Text lvlText;
    public Text shapesText;

    void Start() {
        if(save.LoadData() != null) {
            SaveData data = save.LoadData();
            var timeTaken = Mathf.Round(data.time * 100.0f) * 0.01f;
            timeTakenText.text = "Time Taken: " + timeTaken.ToString();
            scoreText.text = "Score: " + data.score.ToString();
            lvlText.text = "Level: " + data.lvl.ToString();
            shapesText.text = "Shapes Interacted: " + data.shapesInteracted.ToString();
        } else {
            timeTakenText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            lvlText.gameObject.SetActive(false);
            shapesText.gameObject.SetActive(false);
        }
    }
}
