using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }
}
