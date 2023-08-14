using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        
    }

    public void SpawnPlayer()
    {
        // 랜덤 도형 선택
        int randomIndex = Random.Range(0, playerPrefabs.Length);
        GameObject playerPrefab = playerPrefabs[randomIndex];

        // 랜덤 도형 스폰 위치에 소환, 카메라 할당
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

