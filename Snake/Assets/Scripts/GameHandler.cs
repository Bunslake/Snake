using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    void Start() {
        Debug.Log("GameHandler.Start");

        int number = 0;
        FunctionPeriodic.Create(() => {
            CMDebug.TextPopupMouse("Ding!" + number);
            number++;
        }, .3f);
    }

    void Update()
    {
        
    }

}
