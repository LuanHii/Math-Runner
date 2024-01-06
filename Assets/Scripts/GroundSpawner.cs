using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject groundTile2;
    public int groundCount = 0;
    public bool tileQuestionSpawned = false;
    Vector3 nextSpawnPoint;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }
    }


    void Update()
    {
        GameObject questionTile = GameObject.Find("Ground2(Clone)");
        if (questionTile !=null) {
            tileQuestionSpawned = true;
        } else {
            tileQuestionSpawned = false;
        }
    }

    public void SpawnTile()
    {

        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }

    public void SpawnTileQuestion()
    {
        GameObject temp = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        tileQuestionSpawned = true;
        groundCount = 0;
    }


    public bool IsTileQuestionSpawned()
    {
        return tileQuestionSpawned;
    }
}

