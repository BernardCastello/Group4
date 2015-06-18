using UnityEngine;
using System.Collections;

public class TurretPlacement : Singleton<TurretPlacement> 
{
    public GameObject turret1, turret2, turret3, turret4;
    public GameObject dot;
    private GameObject turret;

    private int turretPlaced = 0;
    private int turretCost = 0;
    public bool isSelected = false; //checks to see if a turret is selected



	// Use this for initialization
	void Start () 
    {
        dot.gameObject.SetActive(false);
        turret = turret1;
        if (!isSelected)
        {
            dot.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
    void Update() { HUDManager.instance.TurHUD(turretPlaced);}

    public void TurretWasPlaced()
    {
        Vector3 pos = transform.position + Camera.main.transform.forward * 3;
        pos.y = 0;

        dot.gameObject.SetActive(false);
        Instantiate(turret, pos, transform.rotation);
        isSelected = true;
    }

    public void TurretPlacePoint()
    {

        if (Input.GetMouseButton(0) && isSelected)
        {
            Vector3 pos = transform.position + Camera.main.transform.forward * 3;
            pos.y = 0;
        }

        if (isSelected == true)
        {
            dot.gameObject.SetActive(true);
            isSelected = false;
        }

        ////////////////////////////////

        //if (isSelected == true)
        //{
        //    dot.gameObject.SetActive(true);
        //    Instantiate(turret, pos, transform.rotation);
        //    isSelected = false;
        //    turretPlaced = turretPlaced + 1;
        //}
    }

    public void TurretSelect(KeyCode a)
    {
        if (a == KeyCode.Alpha1) 
            // Player will press #1 - 4 keys to select which type of turret they would like to choose.  
        {

            // The turret placement will be placed in front of the player by 1 unit.
            turret = turret1;
            turretCost = 10;
            isSelected = true;
        }

        if (a == KeyCode.Alpha2)
        {
            
            turret = turret2;
            turretCost = 20;
            isSelected = true;
        }

        if (a == KeyCode.Alpha3)
        {
            
            turret = turret3;
            turretCost = 30;
            isSelected = true;
        }

        if (a == KeyCode.Alpha4)
        {
           
            turret = turret4;
            turretCost = 40;
            isSelected = true;
        }
    }
}
