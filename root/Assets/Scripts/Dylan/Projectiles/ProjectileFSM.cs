using UnityEngine;
using System.Collections;

public class ProjectileFSM : MonoBehaviour 
{
    public int damgaeOutput;

    public enum projectileType
    {
        turretBullet,
        shotgunShell,
        gernade,
    }

    public void OnTriggerEnter(Collider C)
    {
        if(C.gameObject == FindObjectOfType<Stats>().isEnemy)
        {
            Destroy(gameObject);
            C.GetComponent<Stats>().m_Health -= damgaeOutput;
        }
    }
}
