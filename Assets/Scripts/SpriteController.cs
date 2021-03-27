using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Sprite defaultTileSprite;
    public Sprite mineSprite;
    public Sprite securedTileSprite;
    public Sprite securedMineSprite;
    public Sprite deadlyMineSprite;
    public Sprite[] emptyTileSprites;

    public void SetEmptyTileSprite(int minesAround)
    {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[minesAround];
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetSecuredTileSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedTileSprite;
    }

    public void SetSecuredMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetDeadlyMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetDefaultTileSprite()
    {
        GetComponent<SpriteRenderer>().sprite = defaultTileSprite;
    }
}
