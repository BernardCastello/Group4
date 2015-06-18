using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class AI : AICharacterControl
{
    public GameObject goal;
	// Use this for initialization
	void Start ()
    {
        goal = GameObject.FindObjectOfType<GoalStats>().gameObject;
        GetComponent<AICharacterControl>().target = goal.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerStay (Collider other)
    {
        if (other.GetComponent<Stats>() && !other.GetComponent<Stats>().isEnemy)
        {
            if (other.GetComponent<Stats>().isPlayer)
            {
                GetComponent<AICharacterControl>().target = other.transform;
            }
            else if (other.GetComponent<Stats>().isTurret)
            {
                GetComponent<AICharacterControl>().target = other.transform;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Stats>() && !other.GetComponent<Stats>().isEnemy)
        {
            if (other.GetComponent<Stats>().isPlayer)
            {
                GetComponent<AICharacterControl>().target = goal.transform;
            }
            else if (other.GetComponent<Stats>().isTurret)
            {
                GetComponent<AICharacterControl>().target = goal.transform;
            }
        }
    }

}
