using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other) {
    if (groundSpawner.groundCount >= 5 && !groundSpawner.IsTileQuestionSpawned()) {
        groundSpawner.SpawnTileQuestion();
         Destroy(gameObject, 1);
    } else {
        groundSpawner.SpawnTile();
        groundSpawner.groundCount++;
         Destroy(gameObject, 1);
    }
}

    
}
