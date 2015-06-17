using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerFSM
{
    bool canSlap, canJump, canShoot, placeTurret, throwGrenade;
    public Dictionary<string, bool> ActionDict;
    /// <summary>
    /// on construction we will initialize our action list
    /// </summary>
    public PlayerFSM()
    {
        //please work
        canSlap = false;
        canJump = false;
        canShoot = false;
        placeTurret = false;

        ActionDict = new Dictionary<string, bool>();
        ActionDict.Add("slap", canSlap);
        ActionDict.Add("jump", canJump);
        ActionDict.Add("TurretShoot", canShoot);
        ActionDict.Add("PlayerShoot", canShoot);
        ActionDict.Add("placeTurret", placeTurret);
        ActionDict.Add("grenade", throwGrenade);
    }

    /// <summary>
    /// what we want to happen when we are in the current state
    /// </summary>
    /// <param name="state"></param>

    private void HandleTransition(PlayerState state)
    {
        foreach (string Key in new List<string>(ActionDict.Keys))
        {
            switch (state)
            {
                case PlayerState.init: //start up
                    ActionDict[Key] = false; //cant do anything in the dictionary
                    break;

                case PlayerState.idle:
                    ActionDict[Key] = true; //can do everything in the dictionary
                    break;

                case PlayerState.walk:
                    ActionDict[Key] = true; //can do everything in the dictionary
                    break;
                case PlayerState.run:
                    ActionDict["slap"] = false; //cant slap but can do everyting else in the dictionary
                    ActionDict["placeTurret"] = false;
                    break;
                case PlayerState.dead:
                    ActionDict[Key] = false; //cant do everything in the dictionary
                    break;
            }
        }

    }

    protected static PlayerFSM _fsm;
    /// <summary>
    /// validate a transition from one state to another state
    /// </summary>
    /// <param name="from">
    /// our current state 
    /// </param>
    /// <param name="to">
    /// the state we are transitioning to
    /// </param>
    /// <returns>
    /// whether or not we have a valid transition
    /// </returns>
    private bool CheckTransition(PlayerState from, PlayerState to)
    {
        switch (from)
        {
            case PlayerState.init:
                if (to == PlayerState.idle || to == PlayerState.dead)
                {
                    cState = to;
                    return true;
                }
                break;

            case PlayerState.idle:
                if (to == PlayerState.walk || to == PlayerState.dead)
                {
                    cState = to;
                    return true;
                }
                break;

            case PlayerState.walk:
                if (to == PlayerState.run || to == PlayerState.idle || to == PlayerState.dead)
                {
                    cState = to;
                    return true;
                }
                break;

            case PlayerState.run:
                if (to == PlayerState.walk || to == PlayerState.dead)
                {
                    cState = to;
                    return true;
                }
                break;

            default:
                break;

        }
        return false;
    }


    /// <summary>
    /// called from input handler to change the state of the player
    /// </summary>
    /// <param name="to"></param>
    public void ChangeState(PlayerState to)
    {
        CheckTransition(cState, to);
        HandleTransition(to);
    }

    private PlayerState cState = PlayerState.idle;

    public PlayerState CurrentState
    {
        get
        {
            return cState;
        }
    }
}
