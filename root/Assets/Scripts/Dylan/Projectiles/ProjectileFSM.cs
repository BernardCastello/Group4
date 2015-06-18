using UnityEngine;
using System.Collections;

public class ProjectileFSM : MonoBehaviour
{
    public int damgaeOutput;
    public GameObject[] BB; // shots inside of a shot
    public GameObject enemy;
    public float throwPower = 25f;
    private float mySpeed = 20f;
    private float maxDistance = 5f;
    private float myDist;
    private float spreadRate = 100;
    public int bDamage = 10;
    int numOfShots = 10;
   

    public bool isFired = false; //a bool to check if the bullet is beign fired
    public bool doDmg = false;

    public enum projectileType
    {
        turretBullet,
        shotgunShell,
        gernade,
    }

    private projectileType pt;

    public void OnTriggerStay(Collider C)
    {
        if (C.GetComponent<Stats>())
        {

            if (C.GetComponent<Stats>().isEnemy)
            {
                C.GetComponent<Stats>().m_Health -= damgaeOutput;
                Destroy(gameObject);


            }
        }
    }

    //public void OnTriggerStay(Collider c)
    //{
    //    if (c.tag == "Enemy")
    //    {
    //        doDmg = true;
    //        Debug.Log(doDmg);
    //        Destroy(gameObject);
    //        if (doDmg == true)
    //        {
    //            enemy.GetComponent<EnemyStats>().m_Health -= bDamage;
    //            Debug.Log("Im dying");
    //        }
    //    }
    //}

    void Update()
    {
        switch (pt)
        {
            case (projectileType.turretBullet):
             if (isFired == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * mySpeed);
                myDist += Time.deltaTime * mySpeed;

            //moves the bullet across the screen when the turret fire

                if (myDist > maxDistance)
                {
                    Destroy(gameObject);
                    //checks to see if the bullet has passed the maximum distance it can travel
                    //and if it dis destroy the object
                }
                   
            } break;

            case projectileType.gernade:
            if (isFired == true)
            {
            Vector3 forward = transform.TransformDirection(Vector3.forward * throwPower);
            transform.Translate(forward * Time.deltaTime * mySpeed);
            myDist += Time.deltaTime * mySpeed;

            //moves the bullet across the screen when the turret fire

                if (myDist > maxDistance)
                {
                    Destroy(gameObject);
                    //checks to see if the bullet has passed the maximum distance it can travel
                    //and if it dis destroy the object
                }
            }
                break;
            case projectileType.shotgunShell:
            if (isFired == true)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                for (int i = 0; i < numOfShots; numOfShots++)
                {
                    Instantiate(BB[numOfShots], transform.position, transform.rotation);
                }



            //transform.Translate(Vector3.up * Time.deltaTime * mySpeed);

            //forward.x += Random.Range(spreadRate, -spreadRate);
            //forward.y += Random.Range(spreadRate, -spreadRate);
            //forward.z += Random.Range(spreadRate, -spreadRate);

            //BB[numOfShots].transform.LookAt(forward);

            //myDist += Time.deltaTime * mySpeed;
            //if (myDist > maxDistance)
            //{
            //    Destroy(gameObject);
            //    print("Obj Gone");
            //    //checks to see if the bullet has passed the maximum distance it can travel
            //    //and if it dis destroy the object
            //}
            } break;
        }
    }
}
