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
        Destroy(TrashPile.gameObject);
        Instantiate(soundGood);
    }
}
