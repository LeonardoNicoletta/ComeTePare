using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform EnemyContainer;
    [SerializeField] Vector2 rangeSize = new(5, 5);
    [SerializeField] float waitTime=3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitEnemy());
    }
    IEnumerator WaitEnemy()
    {
        yield return new WaitForSeconds(waitTime);
        EnemySpawn();
        StartCoroutine(WaitEnemy());
    }

    void EnemySpawn()
    {
        Vector2 position= new Vector2(spawnPoint.position.x + Random.Range(rangeSize.x,-rangeSize.x),spawnPoint.position.y + Random.Range(rangeSize.x, -rangeSize.x));
        Instantiate(EnemyPrefab, position, Quaternion.identity,EnemyContainer);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(rangeSize.x, rangeSize.y,0)*2);
        //Gizmos.DrawWireCube(spawnPoint.position, (Vector3) rangeSize);
    }
}