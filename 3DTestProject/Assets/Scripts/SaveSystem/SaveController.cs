using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public ScoreController sc;
    public TimeCounter tc;
    public bool mainMenu;

    public void SaveData()
    {
        if(mainMenu == false) {
            SaveSystem.SaveData(tc.time, sc.score, sc.lvl, sc.shapesInteracted);
        }
    }

    public SaveData LoadData() {
        if(SaveSystem.CheckFile()) {
            return SaveSystem.LoadData();
        } else {
            return null;
        }
    }
}
