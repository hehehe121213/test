using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField]
    private Button TutButton ;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;
    [SerializeField]
    private GameObject GameOverPanel;

    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null) { instance = this; }
    }
        public void TutorialButton()
    {
        Time.timeScale = 1;
        TutButton.gameObject.SetActive(false);
    }
    public void SetScore(int score) {
        scoreText.text = "" + score; }

    public void DiedShowPanel(int score) {
        GameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if (score > GameScore.instance.GetHighScore()) {
            GameScore.instance.SetHighScore (score);
        }
        bestScoreText.text = "" + GameScore.instance.GetHighScore();
    }


    public void MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }
    public void Restart()
    {
        Application.LoadLevel("gameplay");
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.gameObject.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        PausePanel.gameObject.SetActive(false);
    }
}

