using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FishSpawn : MonoBehaviour
{
    public GameObject fish;
    public float spawnTime = 2f;
    public float fallSpeed = 40.0f;
    private float timer = 0;
    private int randomNumber;

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

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(600, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(fish, screenPosition, Quaternion.identity);

    }
}