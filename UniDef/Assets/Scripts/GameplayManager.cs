using UnityEngine;
using UnityEngine.UI;
using System;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;

    public int enemyHealth;
    public int score;
    public Text scoreText;
    public Text levelText;
    float timeElapsed;
    public Text timeElapsedText;
    public bool isStarted;
    float spawnRate = 4;
    float nextSpawn;

    public Text coinsEarnedText;
    public GameObject endScreen;

    public int enemiesToSpawn;
    public int enemiesOnTheMap;

    public int enemiesKilled;

    void Update()
    {
        if (isStarted)
        {
            timeElapsed += Time.deltaTime;
            timeElapsedText.text = "Time: " + Math.Truncate(timeElapsed);

            nextSpawn -= Time.deltaTime;
            enemiesOnTheMap = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemiesToSpawn > 0)
            {
                if (nextSpawn <= 0 || enemiesOnTheMap == 0)
                {
                    spawnEnemy();
                    nextSpawn = spawnRate;
                }
            }
        }
    }
    public void startGame()
    {
        endScreen.SetActive(false);

        enemiesToSpawn = Convert.ToInt32(DataHolder.instance.level + 5 * 0.9);
        enemyHealth = Convert.ToInt32(Math.Pow((3 * DataHolder.instance.level),1.32));
        levelText.text = "Level: " + DataHolder.instance.level;
        enemiesKilled = 0;

        Wall.instance.wallHealthText.text = Wall.instance.wallHealth + "/" + DataHolder.instance.wallMaxHealth;

        scoreText.text = "Score: " + score;
        timeElapsed = 0;
        Wall.instance.wallHealth = DataHolder.instance.wallMaxHealth;
        isStarted = true;
    }
    private void spawnEnemy()
    {
        GameObject enemy;
        int rand;

        switch (enemiesToSpawn)
        {
            case 1: rand = 1;
                break;
            case 2:
                rand = UnityEngine.Random.Range(1, 3);
                break;
            case 3:
                rand = UnityEngine.Random.Range(1, 4);
                break;
            case 4:
                rand = UnityEngine.Random.Range(1, 5);
                break;
            default:
                rand = UnityEngine.Random.Range(1, 6);
                break;
        }
        
        switch (rand)
        {
            case 1:
                enemy = Instantiate(enemyPrefab1, new Vector2((Screen.width - 60) * UnityEngine.Random.value, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn--;
                break;
            case 2:
                enemy = Instantiate(enemyPrefab2, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn -= 2;
                break;
            case 3:
                enemy = Instantiate(enemyPrefab3, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn -= 3;
                break;
            case 4:
                enemy = Instantiate(enemyPrefab4, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn -= 4;
                break;
            case 5:
                enemy = Instantiate(enemyPrefab5, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn -= 5;
                break;
            default:
                enemy = Instantiate(enemyPrefab1, new Vector2((Screen.width - 60) * UnityEngine.Random.value, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
                enemiesToSpawn--;
                break;
        }
    }
    public void checkIfEnd()
    {
        if (enemiesToSpawn == 0 && enemiesOnTheMap == 1)
        {
            DataHolder.instance.level++;
            endOfRun();
        }
    }
    public void endOfRun()
    {
        isStarted = false;
        if (DataHolder.instance.highScore < score)
        {
            DataHolder.instance.highScore = score;
        }

        int coinsToAdd = Convert.ToInt32(DataHolder.instance.level * 2 + enemiesKilled * DataHolder.instance.level);
        if (coinsToAdd < 5 && score > 4)
        {
            coinsToAdd = 5;
        }
        DataHolder.instance.coins += coinsToAdd;
        coinsEarnedText.text = "Coins collected: " + coinsToAdd;
        endScreen.SetActive(true);

        SaveManager.instance.JustSave();

        //destroying enemies after failed run
        GameObject[] enemiesToKill = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesToKill.Length; i++)
        {
            Destroy(enemiesToKill[i].gameObject);
        }
    }
}
