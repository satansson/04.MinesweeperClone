using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameButton : MonoBehaviour
{
    public Sprite happyFace;
    public Sprite neutralFace;
    public Sprite sadFace;

    public Button resetButton;

    public void SetHappyFace()
    {
        resetButton.image.sprite = happyFace;
    }

    public void SetNeutralFace()
    {
        resetButton.image.sprite = neutralFace;
    }

    public void SetSadFace()
    {
        resetButton.image.sprite = sadFace;
    }
}
