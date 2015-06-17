using UnityEngine;
using System.Collections;

public class EnemyStates : MonoBehaviour
{

    NavMeshAgent enemy;
    private GameObject target;

    public enum States { Idle, Goal, Chase };
    public States enemyStates = States.Idle;
    /// <summary>
    /// user must set this or dude wont move... this is tran prmse
    /// </summary>
    public Transform goal;
    public float delay;

    public float timer;

	void Start () 
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.autoBraking = false;
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        target = goal.gameObject;
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            target = other.gameObject;

        else if (other.gameObject.tag == "Turret")
            target = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
            target = goal.gameObject;

    }

	void Update () 
    {
        timer += Time.deltaTime;
	    switch(enemyStates)
        {
            case States.Idle:

                enemy.velocity = new Vector3(0, 0, 0);
                
                if (target != gameObject)
                { enemyStates = States.Chase; }

                if(timer > delay)
                { enemyStates = States.Goal; }
                break;

            case States.Goal:

                enemy.destination = goal.position;
                
                if (target != gameObject) 
                { enemyStates = States.Chase; }

                if (Vector3.Distance(enemy.transform.position, enemy.destination) <= enemy.radius)
                    enemy.Stop();
                break;

            case States.Chase:
               
                enemy.destination = target.transform.position;

                if (target == gameObject) 
                { timer = 0; enemyStates = States.Idle; }
                break;

        }

	}
  
}
