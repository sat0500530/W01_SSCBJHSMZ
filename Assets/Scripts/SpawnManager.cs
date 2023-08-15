using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] tetrisPrefabs;
    public Sprite[] tetrisSprites;
    public Sprite nullSprite;

    int nextIndex = -1;

    public Sprite SpawnPlayer(bool isLast)
    {
        GameObject selectedPrefab;
        selectedPrefab = tetrisPrefabs[nextIndex > -1 ? nextIndex : Random.Range(0, tetrisPrefabs.Length)];

        Sprite nextSprite;
        if (isLast)
        {
            nextSprite = nullSprite;
        }
        else
        {
            nextIndex = Random.Range(0, tetrisPrefabs.Length);
            nextSprite = tetrisSprites[nextIndex];
        }

        Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
        return nextSprite;
    }
    
    
}

