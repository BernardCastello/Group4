using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
    public int startingHealth = 3;
    public int currentHealth;

    Animator anim;
    CapsuleCollider capsuleCollider;
    bool isDead;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        
        Destroy(gameObject);
    }

    public void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if(currentHealth<=0)
        {
            Death();
        }
    }

}
