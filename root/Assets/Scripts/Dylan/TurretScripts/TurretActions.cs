using UnityEngine;
using System.Collections;

public class TurretActions : MonoBehaviour, TActions
{
    protected static TurretActions t_instance;
    private TurretFSM t_fsm;

    void Awake()
    {
        t_fsm = new TurretFSM();
        t_instance = this;
    }

    public void Reload()
    {
        if (t_fsm.TurretActions["reload"] == true)
        {
            GetComponent<TurretStats>().m_Ammo = GetComponent<TurretStats>().m_maxAmmo;
            GetComponent<TurretStats>().isReloading = false;
            GetComponent<TurretStats>().turretView.GetComponent<FieldOfView>().isTargetInView = true;
        }   
    }

    public void t_State(TurretState state)
    {
        t_fsm.t_ChangeState(state);
    }

    void t_DistanceToTarget()
    {
        Vector3 aimPoint = new Vector3(GetComponentInParent<TurretStats>().target.transform.position.x,
                                       GetComponentInParent<TurretStats>().target.transform.position.y,
                                       GetComponentInParent<TurretStats>().target.transform.position.z);
        aimPoint.y = GetComponentInParent<TurretStats>().target.transform.localScale.y / 2;
        GetComponentInParent<TurretStats>().rotationToGoal = Quaternion.LookRotation(aimPoint - transform.position);
    }

    void t_Fire(TurretStats.e_TurretType type)
    {
        if (GetComponentInParent<TurretStats>().m_Ammo != 0 &&
            GetComponentInParent<TurretStats>().turretView.GetComponent<FieldOfView>().isTargetInView == true)
        {
            t_State(TurretState.shoot);
            GetComponentInParent<TurretStats>().bullet.GetComponent<BulletMove>().isFired = true;
            GetComponentInParent<TurretStats>().m_Ammo -= 1;

            switch(type)
            {
                case TurretStats.e_TurretType.e_MachineGun:
                    foreach (Transform t_Barrel in GetComponentInParent<TurretStats>().barrelPos)
                    {
                        Instantiate(GetComponentInParent<TurretStats>().bullet, t_Barrel.position, t_Barrel.rotation);
                    }
                    break;

                case TurretStats.e_TurretType.e_ShotGun:
                    foreach (Transform t_Barrel in GetComponentInParent<TurretStats>().barrelPos)
                    {
                        Instantiate(GetComponentInParent<TurretStats>().bullet, t_Barrel.position, t_Barrel.rotation);
                    }
                    break;
            }

            if(GetComponentInParent<TurretStats>().type == TurretStats.e_TurretType.e_AntiAir)
            {
                Vector3 spawnPos = new Vector3(GetComponentInParent<TurretStats>().barrelPos[0].position.x,
                               GetComponentInParent<TurretStats>().barrelPos[0].position.y,
                               GetComponentInParent<TurretStats>().barrelPos[0].position.z);

                GetComponentInParent<TurretStats>().t_cycle++;

                switch (GetComponentInParent<TurretStats>().t_cycle++ % 7)
                {
                    case 1: spawnPos = GetComponentInParent<TurretStats>().barrelPos[0].position; break;
                    case 2: spawnPos = GetComponentInParent<TurretStats>().barrelPos[1].position; break;
                    case 3: spawnPos = GetComponentInParent<TurretStats>().barrelPos[2].position; break;
                    case 4: spawnPos = GetComponentInParent<TurretStats>().barrelPos[3].position; break;
                    case 5: spawnPos = GetComponentInParent<TurretStats>().barrelPos[4].position; break;
                    case 6: spawnPos = GetComponentInParent<TurretStats>().barrelPos[5].position; break;
                }

                Instantiate(GetComponentInParent<TurretStats>().bullet,
                spawnPos,  
                GetComponentInParent<TurretStats>().barrelPos[0].rotation);
            }

            if (GetComponentInParent<TurretStats>().m_Ammo == 0)
            {
                GetComponentInParent<TurretStats>().isReloading = true;
                GetComponentInParent<TurretStats>().turretView.GetComponent<FieldOfView>().isTargetInView = false;
            }
        }
    }

    public static TurretActions TInstance
    {
        get
        {
            return t_instance;
        }
    }

    void Update()
    {
        t_State(TurretState.idle);
        if (GetComponentInParent<TurretStats>().target != null &&
            GetComponentInParent<TurretStats>().isReloading == false &&
            GetComponentInParent<TurretStats>().turretView.GetComponent<FieldOfView>().isTargetInView == true)
        {
            t_State(TurretState.patrol);
            Debug.Log("Hit Me");
            t_DistanceToTarget();
            transform.rotation = Quaternion.Lerp(transform.rotation, GetComponentInParent<TurretStats>().rotationToGoal, Time.deltaTime * GetComponentInParent<TurretStats>().rotationSpeed);

            if (Time.deltaTime > GetComponentInParent<TurretStats>().t_RateOfFire)
                t_Fire(GetComponentInParent<TurretStats>().type);
        }



        if (GetComponentInParent<TurretStats>().isReloading == true)
        {
            Debug.Log("No Ammo");
            Reload();
        }
    }
}
