﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishOneSpawn : MonoBehaviour
{
    public GameObject fish;
    public float spawnTime = 2f;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnRandom();
            timer = 0;
        }
    }
    public void SpawnRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 0), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(fish, screenPosition, Quaternion.identity);
    }
}