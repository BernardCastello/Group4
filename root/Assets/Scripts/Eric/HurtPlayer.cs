using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.GetComponent<PlayerStats>().m_Health -= (int)(Time.deltaTime);
    }
}
