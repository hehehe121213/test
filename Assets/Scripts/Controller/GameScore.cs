﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;
    private const string HIGH_SCORE = "High Score";
    void Awake()
    {
        MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime")) {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    void MakeSingleInstance()
    {
        if(instance != null) { Destroy(gameObject); }
        else { instance = this; DontDestroyOnLoad(gameObject); }
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore(){
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
