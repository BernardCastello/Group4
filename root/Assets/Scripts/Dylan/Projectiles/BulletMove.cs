using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour 
{
    GameObject[] BB; // shots inside of a shot
    public GameObject enemy;

    public float throwPower = 25f;
    
    private float mySpeed = 1f;
    private float maxDistance = 4f;

    private float myDist;
    private float spreadRate = 4;
    public int bDamage = 10;

    int numOfShots = 1;

    public bool isFired = false; //a bool to check if the bullet is beign fired
    public bool doDmg = false;

    public void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Enemy")
        {
            doDmg = true;
            Debug.Log(doDmg);
            Destroy(gameObject);
            if (doDmg == true)
            {
                enemy.GetComponent<EnemyStats>().m_Health -= bDamage;
                Debug.Log("Im dying");
            }
        }
    }

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update ()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if(isFired == true)
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
        }

        if(gameObject.tag=="Bullet" && isFired==true)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward * throwPower);

            transform.Translate(forward * Time.deltaTime * mySpeed);
                        myDist += Time.deltaTime * mySpeed;

            if(myDist>maxDistance)
            {
                Destroy(gameObject);
            }
        }

        if(gameObject.tag=="Grenade" && isFired==true)
        {
            Vector3 up = transform.TransformDirection(Vector3.up * throwPower);
            Vector3 forward = transform.TransformDirection(Vector3.forward*throwPower);
            Vector3 down = transform.TransformDirection(Vector3.down * throwPower);

            transform.Translate(forward * Time.deltaTime * mySpeed);
            transform.Translate(up * Time.deltaTime * mySpeed);
                        myDist += Time.deltaTime * mySpeed;

            if (myDist > maxDistance)
            {
                Destroy(gameObject);
                    //checks to see if the bullet has passed the maximum distance it can travel
                    //and if it dis destroy the object
            } 
        }


        if (gameObject.tag == "ShotGunShell" && isFired == true)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Instantiate(BB[numOfShots], transform.position, transform.rotation);

            transform.Translate(Vector3.up * Time.deltaTime * mySpeed);

            forward.x += Random.Range(spreadRate, -spreadRate);
            forward.y += Random.Range(spreadRate, -spreadRate);
            forward.z += Random.Range(spreadRate, -spreadRate);

            BB[numOfShots].transform.LookAt(forward);

            myDist += Time.deltaTime * mySpeed;
            if (myDist > maxDistance)
            {
                Destroy(gameObject);
                print("Obj Gone");
                //checks to see if the bullet has passed the maximum distance it can travel
                //and if it dis destroy the object
            }
        }
	}
}
