using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector3 Spawn_Area = new Vector3(1f, 1f, 1f);
    [SerializeField] private Transform PlayerTransform;
    public int SpawnAmount = 1;
    public GameObject DronePrefab;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.paleVioletRed;
        Gizmos.DrawCube(transform.position, Spawn_Area);
    }
    
    private IEnumerator SpawnLoop()
    {
        while(true)
        {
            for (int i = 0; i < SpawnAmount; i++)
            {
                SpawnDrones();
            }
            ;
            yield return new WaitForSeconds(5f);    
        }
        
    }

    private void SpawnDrones()
    {
        Vector3 randPoint = new Vector3(
            UnityEngine.Random.Range(-0.5f, 0.5f),
            UnityEngine.Random.Range(-0.5f, 0.5f),
            UnityEngine.Random.Range(-0.5f, 0.5f)
            );


        Vector3 scaledPoint = Vector3.Scale(randPoint, Spawn_Area);
        Vector3 spawnPoint = transform.position + scaledPoint;
        GameObject enemyDrone = Instantiate(DronePrefab, spawnPoint, Quaternion.identity);

        EnemyDroneTransform droneTransform = enemyDrone.GetComponent<EnemyDroneTransform>();

        droneTransform.LerpTime = UnityEngine.Random.Range(1f, 8f);
        droneTransform.endPoint.x = PlayerTransform.position.x;
    }
}
