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
        StartCoroutine(DestroyAndReset());
    } else {
        groundSpawner.SpawnTile();
        groundSpawner.groundCount++;
        StartCoroutine(DestroyAndReset());
    }
}

    private IEnumerator DestroyAndReset()
    {
        Destroy(gameObject, 2);
        yield return new WaitForSeconds(2); 
        
        
    }
}
