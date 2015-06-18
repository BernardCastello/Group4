using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerActions : MonoBehaviour, IActions
{
    [SerializeField]
    public GameObject Grenade;
    string action;
    private Vector3 lastFramePosition;

    void Awake()
    {
        fsm = new PlayerFSM();
        lastFramePosition = transform.position;
        _instance = this;
    }
    public void Slap()
    {
        if (fsm.ActionDict["slap"] == true)
            action = "slap";
    }

    public void Jump()
    {
        if (fsm.ActionDict["jump"] == true)
            action = "jump";
    }

    public void Shoot()
    {
        if (fsm.ActionDict["shoot"] == true)
            action = "shoot";

        Grenade.GetComponent<ProjectileFSM>().isFired = true;       
        Instantiate(Grenade, transform.position, transform.rotation);
    }

    public void PlaceTurret()
    {
        if (fsm.ActionDict["placeTurret"] == true)
        print("turret placed");
    }

    public void State(PlayerState state)
    {        
        fsm.ChangeState(state);
    }

    void Update()
    {
        HUDManager.instance.SetInfoLeft("FPS: " + Time.deltaTime.ToString() + "\n" +
                                        "Player State: " + fsm.CurrentState.ToString() + "\n" +
                                        "Player Action: " + action);

        //consistenet check until i can get zack to change the gamemanager
      //  ShelbyDatabase.instance.sel
    }



    protected static  PlayerActions _instance;
    private PlayerFSM fsm;

    public static PlayerActions instance
    {
        get
        {            
            return _instance;
        }
    }



    void FixedUpdate()
    {
        Vector3 vel = (transform.position - lastFramePosition) / Time.fixedDeltaTime;

        bool idle = Vector3.Distance(transform.position, lastFramePosition) < 0.01;
        lastFramePosition = transform.position;

        bool running = Vector3.Distance(transform.position, lastFramePosition) > 5.00;

        if(idle)
        {
            State(PlayerState.idle);
        }

        if(running)
        {
            State(PlayerState.run);
        }

        if(gameObject.GetComponent<PlayerStats>().m_Health <= 0)
        {
            State(PlayerState.dead);
        }
    }
}
