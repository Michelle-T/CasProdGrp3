using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOnClick : MonoBehaviour
{
    public GameObject TrashPile;
    public GameObject soundGood;
    public GameObject soundBad;

    void OnMouseDown()
    {
        if (GlobalScore.globalScore >= 10)
        {
            GlobalScore.globalScore -= 10;
            Destroy(TrashPile.gameObject);
            Instantiate(soundGood);
        }
        else
        {
            Instantiate(soundBad);
        }
    }
}
