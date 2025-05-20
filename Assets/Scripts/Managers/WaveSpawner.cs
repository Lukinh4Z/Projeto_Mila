using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSpawner;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }
    
    [System.Serializable]
    public class enemySpawn
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public float rate;
        public enemySpawn[] enemies;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    public GameObject winScreen;

    private float dificultFactor = 1.0f;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if(!EnemiesAreAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemiesAreAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    void WaveCompleted()
    {
        //Begin a new round
        Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;

            //winScreen.SetActive(true);
            //Time.timeScale = 0;

            dificultFactor = dificultFactor * 1.2f;

            Debug.Log("Completed waves");

        }
        else
        {
            nextWave++;
        }

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        Debug.Log("Spawning Wave: " + _wave.name);

        for(int i=0; i< _wave.enemies.Length; i++)
        {
            StartCoroutine(SpawnEnemy(_wave.enemies[i]));
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    IEnumerator SpawnEnemy(enemySpawn _enemySpawn)
    {
        int enemiesToSpawn = Mathf.RoundToInt(_enemySpawn.count * dificultFactor);
        Debug.Log("Count: " + _enemySpawn.count + ", factor: " + dificultFactor + ", total: " + enemiesToSpawn);

        for (int i=0; i< enemiesToSpawn; i++)
        {    
            Debug.Log("Spawning enemy: " + _enemySpawn.enemy.name);
            Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(_enemySpawn.enemy, _sp.position, _enemySpawn.enemy.transform.rotation);
            yield return new WaitForSeconds(1f / _enemySpawn.rate);
        }

        yield return null;
    }
}
