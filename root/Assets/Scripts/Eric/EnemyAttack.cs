using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private float damage = 10;

    void OnTriggerStay (Collider other)
    {
        if (other.GetComponent<Stats>() && !other.GetComponent<Stats>().isEnemy)
        {
            if (other.GetComponent<Stats>().isPlayer || other.GetComponent<Stats>().isTurret)
            {
                other.GetComponent<Stats>().m_Health -= (damage * Time.deltaTime);
            }
        }
    }
}
