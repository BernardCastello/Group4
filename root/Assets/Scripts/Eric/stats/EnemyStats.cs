using UnityEngine;
using System.Collections;

public class EnemyStats : Stats
{
    public GameObject Drop;
    public GameObject sDrop;
    public GameObject Item;
    public bool m_PowerLevel;
    public int m_pLvl;
    public bool validTarget = false;

    public float dieTimer, dieDelay;

    void Start()
    {
        isEnemy = true;
        isShootable = true;
        m_Health = m_MaxHealth;
        m_PowerLevel = false;
    }

    void TakeDamage(int amount, Vector3 hitPoint)
    {
        m_Health -= amount;
    }

    void Update()
    {
 
        if (m_Health < 0)
        {
            m_Health = 1;
            Die();
            isShootable = false;
        }

        if (m_Health > 1 && GetComponent<Animator>().enabled == false)
        {
            Destroy(gameObject);
        }

        if (!isShootable)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().speed = 0;

            if (transform.eulerAngles.x < 80)
            { 
                transform.Rotate(Vector3.right * Time.deltaTime * 50); 
            }
            else
            {
                dieTimer += Time.deltaTime;
            }

            if (dieTimer >= dieDelay)
            {
                Destroy(gameObject);
            }

        }
    }

    // What happends when the entiyi dies
    void Die()
    {
        int i = Random.Range(5, 11);
        Vector3 DropPos = gameObject.transform.position;

        for (int j = 1; j <= i; j++)
        {
            DropPos.x += Random.Range(-.5f, .51f);
            DropPos.z += Random.Range(-.5f, .51f);
            DropPos.y = gameObject.transform.position.y; 

            GameObject _specialDrop, _item, _regDrop;

            //rolled 8 spawn an enemy
            if (j == 8)
            {
               _specialDrop = Instantiate(sDrop, DropPos, transform.rotation) as GameObject;
               _specialDrop.name = "Enemy";
            }
            //rolled a 10 spawn an item
            else if (j == 10)
            {
                _item = Instantiate(Item, DropPos, transform.rotation) as GameObject;
                _item.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);    
            }

            else
            {
                _regDrop = Instantiate(Drop, DropPos, transform.rotation) as GameObject;
                _regDrop.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
                _regDrop.name = "Scrap" + j.ToString();
            }
        }
 
    }
}