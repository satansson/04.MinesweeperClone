using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public int highscoreEasy;
    public int highscoreMedium;
    public int highscoreHard;

    public Text highscoreText;

    public DifficultyButtons difficultyButtons;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighscoreEasy"))
        {
            highscoreEasy = PlayerPrefs.GetInt("HighscoreEasy");
        }
        else
        {
            highscoreEasy = 999;
        }


        if (PlayerPrefs.HasKey("HighscoreMedium"))
        {
            highscoreMedium = PlayerPrefs.GetInt("HighscoreMedium");
        }
        else
        {
            highscoreEasy = 999;
        }

        if (PlayerPrefs.HasKey("HighscoreHard"))
        {
            highscoreHard = PlayerPrefs.GetInt("HighscoreHard");
        }
        else
        {
            highscoreEasy = 999;
        }
    }

    void FixedUpdate()
    {
        if (difficultyButtons.currentDifficulty == "easy")
        {
            highscoreText.text = highscoreEasy.ToString();
        }
        else if (difficultyButtons.currentDifficulty == "medium")
        {
            highscoreText.text = highscoreMedium.ToString();
        }
        else if (difficultyButtons.currentDifficulty == "hard")
        {
            highscoreText.text = highscoreHard.ToString();
        }
    }

    public void UpdateHighscore(int score)
    {
        if(difficultyButtons.currentDifficulty == "easy" && score < highscoreEasy)
        {
            highscoreEasy = score;
            PlayerPrefs.SetInt("HighscoreEasy", score);
        }
        else if (difficultyButtons.currentDifficulty == "medium" && score < highscoreMedium)
        {
            highscoreEasy = score;
            PlayerPrefs.SetInt("HighscoreMedium", score);
        }
        else if (difficultyButtons.currentDifficulty == "hard" && score < highscoreHard)
        {
            highscoreHard = score;
            PlayerPrefs.SetInt("HighscoreHard", score);
        }
        PlayerPrefs.Save();
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        highscoreEasy = 999;
        highscoreMedium = 999;
        highscoreHard = 999;
    }
}
