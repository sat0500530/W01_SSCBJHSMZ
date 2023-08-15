using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool isTetris = false;
    public GameObject[] playerPrefabs;
    public GameObject[] tetrisPrefabs;
    public Transform spawnPoint;

    public void SpawnPlayer()
    {
        // 랜덤 도형 선택
        var list = isTetris ? tetrisPrefabs : playerPrefabs;
        int randomIndex = Random.Range(0, list.Length);
        GameObject playerPrefab = list[randomIndex];

        // 랜덤 도형 스폰 위치에 소환, 카메라 할당
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

