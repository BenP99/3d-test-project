using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject winMenu;
    public ScoreController sc;
    public SaveController save;
    public bool pause;

    void Start()
    {
        winMenu.SetActive(false);
        pause = false;
    }

    void Update() {
        if(sc.score == 400) {
            ShowWinMenu();
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
