using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreBlue : MonoBehaviour
{
    public static event Action pointBlue;
    public bool canScore = true;
    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.name == "ball")
        {
            if (canScore == true)
            {
                if (pointBlue != null)
                {
                    pointBlue();
                }
            }
        }
    }


}
