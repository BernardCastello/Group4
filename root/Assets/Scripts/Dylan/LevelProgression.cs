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

    private void progress()
    {
        curWave = curWave + 1;
        goalKillCount = goalKillCount * curWave;
        numOfEnemies = numOfEnemies * curWave;
    }

    void Update()
    {
        if(numOfKills >= goalKillCount && curWave != numOfWaves)
        {
            progress();
        }
        if(numOfKills >= goalKillCount && curWave == numOfWaves)
        {
            gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        }
    }
	
}
