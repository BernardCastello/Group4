using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour 
{
    public GameObject gameManager;
    public GameObject enemy;
    public int numOfWaves = 5;
    public int curWave = 1;

    public int goalKillCount = 10;
    public int numOfKills = 0;
    public int numOfEnemies = 10; //the number of enemies in the round

    float delayProgress = Time.deltaTime * 25;

    private void progress()
    {
        curWave = curWave + 1;
        goalKillCount = 10 * curWave;
        numOfEnemies = numOfEnemies * curWave;
        numOfKills = 0;
    }


    void Update()
    {
        if(enemy.GetComponent<EnemyStats>().c_EState == EnemyState.Dead)
        {
            numOfKills = numOfKills + 1;
        }

        if (numOfKills >= goalKillCount && curWave != numOfWaves)
        {
            FindObjectOfType<SpawnEnemy>().canSpawn = false;
            progress();
            if (Time.deltaTime >= delayProgress)
            {
                FindObjectOfType<SpawnEnemy>().canSpawn = true;
            }
        }

        if (numOfKills >= goalKillCount && curWave == numOfWaves)
        {
            gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        }
    }
	
}
