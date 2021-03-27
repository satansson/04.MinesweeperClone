using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minefield : MonoBehaviour
{
    public Timer timer;
    public ResetGameButton resetGameButton;
    public Highscore highscore;

    public int minesAmount;
    public int minesLeft = 0;
    public int tilesUnrevealed;
    public bool hasGameStarted = false;

    public int xTotal;
    public int yTotal;

    public Tile[,] tiles;

    public void CreateMinefield(int xTotal, int yTotal, int minesAmount)
    {
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.minesAmount = minesAmount;
        tilesUnrevealed = xTotal * yTotal;
        hasGameStarted = false;

        minesLeft = minesAmount;
        timer.ResetTimer();
        resetGameButton.SetNeutralFace();


        if(tiles != null)
        {
            foreach(Tile tile in tiles)
            {
                Destroy(tile.gameObject);
            }
        }

        tiles = new Tile[xTotal, yTotal];

        for(int x = 0; x < xTotal; x++)
        {
            for (int y = 0; y < xTotal; y++)
            {
                tiles[x, y] = Tile.CreateNewTile(x, y);
            }
        }
    }

    public bool IsGameWon()
    {
        if (tilesUnrevealed == minesAmount)
            return true;
        else
            return false;
    }

    public void WinGame()
    {
        Debug.Log("Game Won!");
        timer.StopTimer();
        resetGameButton.SetHappyFace();

        foreach(Tile tile in tiles)
        {
            if (tile.isMine)
            {
                tile.spriteController.SetMineSprite();
            }
        }

        highscore.UpdateHighscore(timer.GetCurrentTime());
    }

    public void LoseGame()
    {
        Debug.Log("Game Lost");
        timer.StopTimer();
        resetGameButton.SetSadFace();

        foreach (Tile tile in tiles)
        {
            if (!tile.isMine)
            {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                tile.spriteController.SetSecuredMineSprite();
            }
        }
    }
}
