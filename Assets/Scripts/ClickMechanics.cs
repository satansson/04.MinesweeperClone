using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMechanics : MonoBehaviour
{
    Minefield minefield;
    SpriteController spriteController;
    Tile tile;


    // Start is called before the first frame update
    void Start()
    {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        spriteController = GetComponent<SpriteController>();
        tile = GetComponent<Tile>();
    }

    private void OnMouseUpAsButton()
    {
        ClickOnTile();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (tile.isSecured)
            {
                spriteController.SetDefaultTileSprite();
                tile.isSecured = false;
                minefield.minesLeft++;
            }
            else
            {
                spriteController.SetSecuredTileSprite();
                tile.isSecured = true;
                minefield.minesLeft--;
            }
        }
    }

    void ClickOnTile()
    {
        if (!minefield.hasGameStarted)
        {
            minefield.hasGameStarted = true;
            CreateMines();
            minefield.timer.StartTimer();
        }

        if (tile.isMine)
        {
            Debug.Log("Game Over");
            spriteController.SetDeadlyMineSprite();
            minefield.LoseGame();     
        }
        else
        {
            RevealTile();

            if (minefield.IsGameWon())
            {
                minefield.WinGame();
            }
        }
    }

    void CreateMines()
    {
        Debug.Log("Create Mines");

        int minesLeft = minefield.minesAmount;
        int tilesLeft = minefield.tilesUnrevealed;

        for(int x = 0; x < minefield.xTotal; x++)
        {
            for (int y = 0; y < minefield.yTotal; y++)
            {
                if (!(x == tile.x && y == tile.y))
                {
                    Tile aTile = minefield.tiles[x, y];

                    float chanseForMine = (float)minesLeft / (float)tilesLeft;

                    if (Random.value <= chanseForMine)
                    {
                        aTile.isMine = true;
                        minesLeft--;
                    }
                }
                tilesLeft--;
            }
        }
    }

    public void RevealTile()
    {
        if(!tile.isRevealed && !tile.isMine)
        {
            tile.isRevealed = true;
            minefield.tilesUnrevealed--;

            int minesAround = GetMinesAround();

            spriteController.SetEmptyTileSprite(minesAround);

            if(minesAround == 0)
            {
                RevealIfValid(tile.x - 1, tile.y - 1);
                RevealIfValid(tile.x - 1, tile.y);
                RevealIfValid(tile.x - 1, tile.y + 1);

                RevealIfValid(tile.x, tile.y - 1);
                RevealIfValid(tile.x, tile.y + 1);

                RevealIfValid(tile.x + 1, tile.y - 1);
                RevealIfValid(tile.x + 1, tile.y);
                RevealIfValid(tile.x + 1, tile.y + 1);
            }
        }
    }

    void RevealIfValid(int x, int y)
    {
        if(x >= 0 && x < minefield.xTotal && y >= 0 && y < minefield.yTotal)
        {
            minefield.tiles[x, y].clickMechanics.RevealTile();
        }
    }

    public int GetMinesAround()
    {
        int mineCounter = 0;

        if (hasMine(tile.x - 1, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x - 1, tile.y)) mineCounter++;
        if (hasMine(tile.x - 1, tile.y + 1)) mineCounter++;

        if (hasMine(tile.x, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x, tile.y + 1)) mineCounter++;

        if (hasMine(tile.x + 1, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x + 1, tile.y)) mineCounter++;
        if (hasMine(tile.x + 1, tile.y + 1)) mineCounter++;

        return mineCounter;
    }

    bool hasMine(int x, int y)
    {
        bool hasMine = false;

        if(x >= 0 && x < minefield.xTotal && y >= 0 && y < minefield.yTotal)
            {
                hasMine = minefield.tiles[x, y].isMine;
            }
        
        return hasMine;
    }
}
