using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private bool _stopSpawn = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(PowerUpRoutine());
    }


    IEnumerator SpawnRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator PowerUpRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_tripleShotPrefab, posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f,10f));
        }
    }

    public void StopSpawn()
    {
        _stopSpawn = true;
    }
}
