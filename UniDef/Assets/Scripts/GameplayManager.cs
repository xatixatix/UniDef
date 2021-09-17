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

    public GameObject enemyPrefab0;

    public int enemyHealth;
    public int score;
    public Text scoreText;
    float timeElapsed;
    public Text timeElapsedText;
    public bool isStarted;
    float spawnRate = 5;
    float nextSpawn;

    void Update()
    {
        if (isStarted)
        {
            timeElapsed += Time.deltaTime;
            timeElapsedText.text = "Time: " + Math.Truncate(timeElapsed);

            nextSpawn -= Time.deltaTime;
            if (nextSpawn <= 0)
            {
                spawnEnemy(1);
                nextSpawn = spawnRate;
            }
        }
    }
    public void startGame()
    {
        scoreText.text = "Score: " + score;
        timeElapsed = 0;
        Wall.instance.wallHealth = DataHolder.instance.wallMaxHealth;
        isStarted = true;
    }
    private void spawnEnemy(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab0, new Vector2((Screen.width - 60) * UnityEngine.Random.value, Screen.height), Quaternion.identity, GameObject.FindGameObjectWithTag("GameCanvas").transform) as GameObject;
        }
    }
    public void endOfRun()
    {
        isStarted = false;
        if (DataHolder.instance.highScore < score)
        {
            DataHolder.instance.highScore = score;
        }

        int coinsToAdd = Convert.ToInt32(score / 3 * ((DataHolder.instance.laserU + DataHolder.instance.speedU +DataHolder.instance.fireRateU) / 3));
        if (coinsToAdd < 5 && score > 10)
        {
            coinsToAdd = 5;
        }
        DataHolder.instance.coins += coinsToAdd;

        SaveManager.instance.JustSave();
    }
}
