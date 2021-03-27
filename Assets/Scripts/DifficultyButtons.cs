using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    Minefield minefield;
    public string currentDifficulty = "easy";

    // Start is called before the first frame update
    void Start()
    {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        SetEasy();
    }

    public void SetEasy()
    {
        minefield.CreateMinefield(10, 10, 10);
        currentDifficulty = "easy";
    }

    public void SetMedium()
    {
        minefield.CreateMinefield(20, 20, 40);
        currentDifficulty = "medium";
    }

    public void SetHard()
    {
        minefield.CreateMinefield(30, 30, 90);
        currentDifficulty = "hard";
    }

    public void ResetGame()
    {
        if (currentDifficulty == "easy")
            SetEasy();
        else if (currentDifficulty == "medium")
            SetMedium();
        else if (currentDifficulty == "hard")
            SetHard();
    }
}
