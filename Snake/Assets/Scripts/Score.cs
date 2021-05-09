using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{

    public static event EventHandler OnHighscorechanged;
    
    private static int score;
    public static void InitializeStatic()
    {
        OnHighscorechanged = null;
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighscore(score);
    }


    public static bool TrySetNewHighscore(int score)
    {
        int highscore = GetHighscore();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            if (OnHighscorechanged != null) OnHighscorechanged(null, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}
