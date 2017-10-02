using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreRed : MonoBehaviour {
    public static event Action pointRed;
    public bool canScore = true;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ball")
        {
            if (canScore == true) {
                if (pointRed != null) {
                    pointRed();
                }
            }
        }
    }
}
