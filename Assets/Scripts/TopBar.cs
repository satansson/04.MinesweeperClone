using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    Minefield minefield;

    // Start is called before the first frame update
    void Start()
    {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(0, (minefield.yTotal - 1f) / 2f + 2f);

        RectTransform rectTrans = (RectTransform)transform;
        rectTrans.sizeDelta = new Vector2(minefield.xTotal + 3, 3);
    }
}
