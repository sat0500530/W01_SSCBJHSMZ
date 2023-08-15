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
        // ���� ���� ����
        var list = isTetris ? tetrisPrefabs : playerPrefabs;
        int randomIndex = Random.Range(0, list.Length);
        GameObject playerPrefab = list[randomIndex];

        // ���� ���� ���� ��ġ�� ��ȯ, ī�޶� �Ҵ�
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

