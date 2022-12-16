using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float time;
    public bool stopCount;

    void Start() {
        stopCount = false;
    }

    void Update()
    {
        if(stopCount == false) {
            time += Time.deltaTime;
        }
    }
}
