using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    private GameObject player;
    private GameObject turretManager;
    [SerializeField]
    private GameObject turret;
    private GameObject Enemy;
    private GameObject goal;


    //Stores all the keys for each input that should perform an action
    //GameStates
    public KeyCode halfPause = KeyCode.C;
    public KeyCode pause = KeyCode.X;
    public KeyCode unpause = KeyCode.Z;
    public KeyCode StartGame = KeyCode.E;

    //player turret selections and placements
    public KeyCode tTurret1 = KeyCode.Alpha1;
    public KeyCode tTurret2 = KeyCode.Alpha2;
    public KeyCode tTurret3 = KeyCode.Alpha3;
    public KeyCode tTurret4 = KeyCode.Alpha4;
    public KeyCode place = KeyCode.Mouse1;

    //player movement controls
    public KeyCode walkForward = KeyCode.W;
    public KeyCode walkBack = KeyCode.S;
    public KeyCode walkLeft = KeyCode.A;
    public KeyCode walkRight = KeyCode.D;
    public KeyCode toggelRun = KeyCode.LeftShift;
    public KeyCode slap = KeyCode.F;
    public KeyCode shoot = KeyCode.V;
    public KeyCode jump = KeyCode.Space;
    public KeyCode grenade = KeyCode.T;

    //player state change controls
    public KeyCode init = KeyCode.I;
    public KeyCode idle = KeyCode.O;

    //Dev controls
    public KeyCode killTurret = KeyCode.B;
    public KeyCode endGame = KeyCode.G;
    public KeyCode killEnemy = KeyCode.V;

    // Update is called once per frame
    delegate void PauseDelegate();
    delegate void NumberDelegate(int n);
    public int num = 0;
    public bool paused = false;
    NumberDelegate numMultiDel;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goal = GameObject.FindGameObjectWithTag("Goal");
    }
    void Update()
    {
        turretManager = GameObject.FindGameObjectWithTag("TurretManager");
        turret = GameObject.FindGameObjectWithTag("MG");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        turretManager = GameObject.FindGameObjectWithTag("TurretManager");
        //Game State changes
        if (Input.GetKeyDown(halfPause))
        {
            /// Pause State Half (Update at Half speed)
            GameManager.instance.Pause(GameManager.PauseState.Half);
        }

        if (Input.GetKeyDown(pause))
        {
            if (!paused)
            {
                GameManager.instance.Pause(GameManager.PauseState.Full);
                print("pausing");
                paused = !paused;
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                HUDManager.instance.SetState("menu", true);
            }
            else
            {
                GameManager.instance.Pause(GameManager.PauseState.None);
                print("unpause");
                paused = !paused;
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                HUDManager.instance.SetState("menu", false);
            }
        }




        ////Player States
        if (Input.GetKeyDown(walkForward)) //Walk forwrad
        {
            player.GetComponent<PlayerActions>().State(PlayerState.walk);
        }

        if (Input.GetKeyDown(walkBack)) //Walk to the back
        {
            player.GetComponent<PlayerActions>().State(PlayerState.walk);
        }

        if (Input.GetKeyDown(walkLeft)) //Walk left
        {
            player.GetComponent<PlayerActions>().State(PlayerState.walk);
        }

        if (Input.GetKeyDown(walkRight)) //Walk to the right
        {
            player.GetComponent<PlayerActions>().State(PlayerState.walk);
        }

        if (Input.GetKeyDown(toggelRun)) //toggles run on
        {
            player.GetComponent<PlayerActions>().State(PlayerState.run);
        }
        if (Input.GetKeyUp(toggelRun)) //toggles run off
        {
            player.GetComponent<PlayerActions>().State(PlayerState.walk);
        }

        if (Input.GetKeyDown(idle)) //toggles idles
        {
            player.GetComponent<PlayerActions>().State(PlayerState.idle);
        }

        if (Input.GetKeyDown(init)) //toggles init
        {
            player.GetComponent<PlayerActions>().State(PlayerState.init);
        }

        ////Player turret Selction and placement
        if (Input.GetKeyDown(tTurret1))
        {
            turretManager.GetComponent<TurretPlacement>().TurretSelect(tTurret1);
        }
        if (Input.GetKeyDown(tTurret2))
        {
            turretManager.GetComponent<TurretPlacement>().TurretSelect(tTurret2);
        }
        if (Input.GetKeyDown(tTurret3))
        {
            turretManager.GetComponent<TurretPlacement>().TurretSelect(tTurret3);
        }
        if (Input.GetKeyDown(tTurret4))
        {
            turretManager.GetComponent<TurretPlacement>().TurretSelect(tTurret4);
        }

        if (Input.GetKeyDown(place))
        {
            turretManager.GetComponent<TurretPlacement>().TurretPlacePoint();
        }

        ////Player Actions
        if (Input.GetKeyDown(slap))
        {
            player.GetComponent<PlayerActions>().Slap();
        }

        //if (Input.GetKeyDown(shoot))
        //{
        //    player.GetComponent<PlayerActions>().Shoot();
        //}

        if (Input.GetKeyDown(jump))
        {
            player.GetComponent<PlayerActions>().Jump();
        }

        if(Input.GetKeyDown(grenade))
        {
            player.GetComponent<PlayerActions>().Grenades();
        }

        /////Dev Controls
        if (Input.GetKeyDown(killTurret))
        {
            turret.GetComponent<BaseTurret>().m_Health -= 101;
        }
        if (Input.GetKeyDown(killEnemy))
        {
            try
            {
                Enemy.GetComponent<EnemyStats>().m_Health -= 101;
            }
            catch
            {
                Debug.LogWarning("there is no enemies :( ");
            }
        }
        if (Input.GetKeyDown(endGame))
        {
            goal.GetComponent<GoalPoint>().m_Health -= 101;
        }
    }
}