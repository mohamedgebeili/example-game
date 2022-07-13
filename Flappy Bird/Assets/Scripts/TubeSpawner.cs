using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float spawnCooldownTime = 1;
    [SerializeField] private float tubeYPosMax = 1;
    [SerializeField] private float tubeYPosMin = -1;
    [SerializeField] private float tubeSpeed = 1;
    [SerializeField] private float tubeAliveTime = 5;

    [Header("References")]
    [SerializeField] private GameObject tubeCombo;
    [SerializeField] private GameObject startPoint;

    private float spawnCountdown = 0;

    private void SpawnTube()
    {
        // Spawn tube
        float randomY = Random.Range(tubeYPosMin, tubeYPosMax);
        Vector3 spawnPos = new Vector3(startPoint.transform.position.x, randomY, startPoint.transform.position.y);
        GameObject currentTubeCombo = Instantiate(tubeCombo, spawnPos, Quaternion.identity);

        // Get it to move
        currentTubeCombo.GetComponent<TubeCombo>().SetSpeed(tubeSpeed);

        // Destroy it after some time
        Destroy(currentTubeCombo, tubeAliveTime);
    }

    private void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0)
        {
            SpawnTube();
            spawnCountdown = spawnCooldownTime;
        }
    }
}
