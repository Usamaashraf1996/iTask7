using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemeyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 5.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public TMP_Text currentScore;
    public int score = 0;
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;    
    }
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        currentScore.text="GameScore:"+score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//use for instatiate one enemy at time
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

        }
    }
    void SpawnEnemyWave(int spawnToenemy)
    {
        if (PlayerController.gameOver==false)
        {
            for (int i = 0; i < spawnToenemy; i++)
            {

                Instantiate(enemeyPrefab, GenerateSpawnPosition(), enemeyPrefab.transform.rotation);
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

            }
        }
        //if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        //{
        //    Instantiate(powerUpPrefab, GenerateSpawnPosition() , powerUpPrefab.transform.rotation);
        //}

    }
    private Vector3 GenerateSpawnPosition()
    {

        float spawnX = Random.Range(spawnRange, -spawnRange);
        float spawnZ = Random.Range(spawnRange, -spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
       
    }
    public void Add() {

        score += 1;
        currentScore.text = "GameScore"+score.ToString();
    }

}


