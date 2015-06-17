using UnityEngine;
using System.Collections;

public class GameManaagerFSM : MonoBehaviour 
{
    protected static GameManaagerFSM gM_FSM;

    public void GameStateChange(GameStates to)
    {
        checkStateChange(c_gState, to);
    }

    private GameStates c_gState;

    public GameStates CurrentGState
    {
        get
        {
            return c_gState;
        }
    }


    private bool checkStateChange(GameStates to, GameStates from)
    {
        switch(from)
        {
            case GameStates.init:
                if(to == GameStates.mainMenu)
                {
                    c_gState = to;
                    return true;
                }
                break;
            case GameStates.mainMenu:
                if(to == GameStates.gamePlay)
                {
                    c_gState = to;
                    return true;
                }
                break;
            case GameStates.gamePlay:
                if(to == GameStates.pause || to == GameStates.gameOver)
                {
                    c_gState = to;
                    return true;
                }
                break;
            case GameStates.pause:
                if(to == GameStates.mainMenu || to == GameStates.close || to == GameStates.gamePlay)
                {
                    c_gState = to;
                    return true;
                }
                break;
            case GameStates.gameOver:
                if(to == GameStates.close || to == GameStates.mainMenu)
                {
                    c_gState = to;
                    return true;
                }
                break;
            default:
                break;
        }
        return false;
    }
}
