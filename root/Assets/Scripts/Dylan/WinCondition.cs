using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour 
{
    public GameObject playerInv;
    public GameObject gameManager;
    public GameObject player;
    public GameObject progress;

    public AudioClip Dead;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (playerInv.GetComponent<ItemDatabase>().scraps >= scarpGoal ||
        //    player.GetComponent<PlayerStats>().m_Health <= 0)
        //{
        //    Debug.Log("You Win");
        //    gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        //}

        if(progress.GetComponent<LevelProgression>().curWave > progress.GetComponent<LevelProgression>().numOfWaves)
        {
            gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        }

        if(player.GetComponent<PlayerStats>().m_Health <= 0)
        {
            AudioManager.instance.PlayAudio(Dead);
            gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        }

        GameObject.Find("HUDManager").GetComponent<HUDManager>().ScrapHUD(playerInv.GetComponent<ItemDatabase>().scraps);

	}
}
