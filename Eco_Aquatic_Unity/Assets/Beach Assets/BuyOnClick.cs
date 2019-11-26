using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOnClick : MonoBehaviour
{
    public GameObject TrashPile;

    void OnMouseDown()
    {
        Debug.Log("Stop that, it tickles!");
        Destroy(TrashPile.gameObject);
    }
}
