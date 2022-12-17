using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float time;
    public MenuController mc;

    void Update()
    {
        if(mc.pause == false) {
            time += Time.deltaTime;
        }
    }
}
