﻿using UnityEngine;
using System.Collections;

public class BaseTurret : Stats
{
    public GameObject bullet; //prefab for the bullet
    public GameObject turretView;

    public GameObject target;
    public Transform[] barrelPos; //refrence to the pos of the barrel
    public Transform[] turretTop; //refrence to the pos of the top of the turret

    public float rotationSpeed = 5.0f; //Sets the rotation speed for the turret to travel to get to the targets position
    public float reloadSpeed = 5.0f; //The time for the turret to replinish its ammo (also will be a rest time no turret movement)
    public float rateOfFire = 1.0f; //how fast the turret will fire

    public int maxAmmo = 100; //how mmuch ammo the turret can hold
    public int currentAmmo = 100; //how many shots the turret has is decressed by one for every shot unless the turret has multiple barrels

    public int damage = 5;

    int looper = 1;

    public bool isTargetInRadius = false; //checks to see if the target is in the radius of the turret
    public bool isReloading = false;

    public bool validTarget = false;
    private Quaternion rotationToGoal;

    private float fireDelay = 1;
    public float reloadTime;


    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            c.GetComponent<EnemyStats>().validTarget = true;
            validTarget = true;
            target = c.gameObject;
            isTargetInRadius = true;
        }
    }

    public void OnTriggerStay(Collider c)
    {
        if (target != null)
        {
            if (c.gameObject.tag == "Enemy")
            {
                bool enemyState = c.GetComponent<EnemyStats>().validTarget;
                if (enemyState)
                {
                    c.GetComponent<EnemyStats>().validTarget = true;
                    validTarget = true;
                    target = c.gameObject;
                    isTargetInRadius = true;
                }
            }

        }
    }

    public void OnTriggerExit()
    {
        isTargetInRadius = false;
        turretView.GetComponent<FieldOfView>().isTargetInView = false;
    }

    void distanceToTarget(Vector3 targetPos)
    {
        Vector3 aimPoint = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        aimPoint.y = target.transform.localScale.y / 2;
        rotationToGoal = Quaternion.LookRotation(aimPoint - transform.position);
        /*
            used to calculate the distance the turret must rotate till it reaches its targets position
        */
    }

    void bulletFire()
    {


        if (currentAmmo != 0 && turretView.GetComponent<FieldOfView>().isTargetInView == true)
        {
            bullet.GetComponent<BulletMove>().isFired = true;
            currentAmmo -= 1;

            //Fire mechanics for the MachineGun turret
            //gets the position of the barrel and spawns the 
            //bullet at that barrels position
            if (gameObject.tag == "MG")
            {
                foreach (Transform theBarrelPos in barrelPos)
                {
                    Instantiate(bullet, theBarrelPos.position, theBarrelPos.rotation);
                    bullet_cd = 0;
                    print("Shoot");
                }
            }

            //Fire mechanics for the AA Turret
            //Gets the positions of the barrels and assigns the
            //spawn positions for the bullet based on the
            //case selected for the barrel's location that
            //we want the bullet to spawn
            if (gameObject.tag == "AA")
            {
                Vector3 spawnPos = new Vector3(barrelPos[0].position.x,
                                               barrelPos[0].position.y,
                                               barrelPos[0].position.z);
                looper++;

                switch (looper % 7)
                {
                    case 1: spawnPos = barrelPos[0].position; print("Fire 1"); break;
                    case 2: spawnPos = barrelPos[1].position; print("Fire 2"); break;
                    case 3: spawnPos = barrelPos[2].position; print("Fire 3"); break;
                    case 4: spawnPos = barrelPos[3].position; print("Fire 4"); break;
                    case 5: spawnPos = barrelPos[4].position; print("Fire 5"); break;
                    case 6: spawnPos = barrelPos[5].position; print("Fire 6"); break;
                }

                Instantiate(bullet, spawnPos, barrelPos[1].rotation);

            }

            if (currentAmmo == 0)
            {
                isReloading = true;
                turretView.GetComponent<FieldOfView>().isTargetInView = false;
            }
            /*
                set a delay for the RateOfFire and this loops through each of the posistions of the 
             *  turrets barrels to spawn a new bullet in the barrel to be fired agian
             */
        }



    }

    void turretReload()
    {
        reloadTime = Time.time + reloadSpeed;
        currentAmmo = maxAmmo;
        isReloading = false;
        turretView.GetComponent<FieldOfView>().isTargetInView = true;

        /*
  * checks to see if the turret has bullets to fire, if not it reloads.
  * if it has bullets then the turret will begin to fire at the target.
  */
    }

    // Use this for initialization
    void Start()
    {
        m_Health = 100;
    }

    public float bullet_cd;
    public bool bulletFired;
    // Update is called once per frame
    void Update()
    {

        if (bulletFired)
            bullet_cd -= Time.deltaTime;



        if (isTargetInRadius == true && isReloading == false && validTarget == true)
        {
            
            if (target != null)
            {
                if (target.GetComponent<EnemyStats>().validTarget && target.GetComponent<EnemyStats>().dead == false)
                {
                    distanceToTarget(target.transform.position);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationToGoal, Time.deltaTime * rotationSpeed);
                    bulletFired = true;

                    if (bullet_cd <= 0)
                    {

                        bulletFire();
                        bullet_cd = 1;
                        bulletFired = false;
                    }



                    /*
                        when the target comes into the radius of the turret the turret will begin to rotate till 
                     * the target is in its field of view and once it comes into the field of view it will begin to fire
                     */
                }

                if (m_Health <= 0)
                {
                    print("I dead");
                    Destroy(gameObject);
                }

                if (isReloading == true)
                {
                    if (bullet_cd > reloadTime)
                    {
                        turretReload();
                        print("Reloading");
                    }
                }
            }
        }
        
    }


}