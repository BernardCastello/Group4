using UnityEngine;
using System.Collections;

public class GoalStats : Stats
{
    void Start()
    {
        isGoal = true;
        m_Health = 100;
    }

    void Update()
    {
        if (m_Health <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
        GetComponent<LevelLoader>().loadLevel("Exit");
    }
}
