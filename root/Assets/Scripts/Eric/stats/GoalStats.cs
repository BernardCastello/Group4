using UnityEngine;
using System.Collections;

public class GoalStats : Stats
{
    void Start()
    {
        m_Health = m_MaxHealth;
        isGoal = true;
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
