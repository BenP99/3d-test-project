using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject winMenu;
    public ScoreController sc;
    public TimeCounter tc;
    public SaveController save;
    public bool pause;
    public Text timeText;
    public Text scoreText;
    public Text lvlText;

    void Start()
    {
        winMenu.SetActive(false);
        pause = false;
    }

    void Update() {
        if(sc.score == 400) {
            ShowWinMenu();
        }

        if(pause == false) {
            var timeTaken = Mathf.Round(tc.time * 100.0f) * 0.01f;
            timeText.text = "Time: " + timeTaken.ToString();
            scoreText.text = "Score: " + sc.score.ToString();
            lvlText.text = "Level: " + sc.lvl.ToString();
        } else {
            timeText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            lvlText.gameObject.SetActive(false);
        }
    }

    public void ShowWinMenu() {
        save.SaveData();
        winMenu.SetActive(true);
        winMenu.GetComponent<TextUIController>().SetValues();
        pause = true;
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLvl() {
        Scene lvl = SceneManager.GetActiveScene();
        SceneManager.LoadScene(lvl.name);
    }
}
