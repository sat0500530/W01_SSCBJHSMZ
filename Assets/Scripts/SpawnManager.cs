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
        // ���� ���� ����
        int randomIndex = Random.Range(0, playerPrefabs.Length);
        GameObject playerPrefab = playerPrefabs[randomIndex];

        // ���� ���� ���� ��ġ�� ��ȯ, ī�޶� �Ҵ�
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

