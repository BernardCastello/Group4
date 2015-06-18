using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public Transform[] spawnPoints;

    private float m_Timer;
    public float  SpawnDelay;
    public bool canSpawn;

    int enemyCount = 0;

    void Start()
    {
        m_Timer = 0;
        SpawnDelay = 3;
        canSpawn = true;
    }

	void Update ()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= SpawnDelay && canSpawn)
        {
            m_Timer = 0;
            int pos = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[pos].position, transform.rotation);
        }
	}
}
