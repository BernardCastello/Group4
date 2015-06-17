using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class HUDManager : Singleton<HUDManager>
{
   



    /// <summary>
    /// Changes the Text for hp,turrent,scrap 
    /// </summary>
    /// <usedby>ScoreManager (Each function is used by the simular "Score" Funcion in the ScoreManager)</usedby>
    /// // // // // // // // // // // // // // // // // // // // // // // // // // // //
    /// 

    //Displays the amount of health the player has next to the max health the player can have
    
    public void HpHUD(int curHp, int maxHp)
    {
        string curString = curHp.ToString("#.#");
        string maxString = maxHp.ToString("#.#");

        if (curHp >= 10000)
        {

            curHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }
        if (maxHp >= 10000)
        {
            maxHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }


        hp.GetComponent<Text>().text = curString + '/' + maxString;
        if(hpBar)
        helthBar(curHp, maxHp);
    }
    public void HpHUD(float curHp, float maxHp)
    {
        string curString = curHp.ToString("#.#");
        string maxString = maxHp.ToString("#.#");

        if (curHp >= 10000)
        {
            curHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }
        if (maxHp >= 10000)
        {
            maxHp /= 1000;
            maxString = curHp.ToString("#.#") + 'K';
        }


        hp.GetComponent<Text>().text = curString + '/' + maxString;
        if (hpBar)
            helthBar(curHp, maxHp);
        
    }
    // Pass a bool at the end for true = Health Bar (Object with Scroll scrip) and false = no Health Bar
    public void UseHelthBar(bool hpbar = true)
    {
        hpBar = hpbar; 
    }

    private void helthBar(float curHP, float maxHp)
    {
        healthBar.GetComponent<Slider>().maxValue = maxHp;
        healthBar.GetComponent<Slider>().value = curHP;
    }
    private void helthBar(int curHP, int maxHp)
    {
        healthBar.GetComponent<Slider>().maxValue = maxHp;
        healthBar.GetComponent<Slider>().value = curHP;
    }



    public void CoinHpHUD(int curHp, int maxHp)
    {
        string curString = curHp.ToString("#.#");
        string maxString = maxHp.ToString("#.#");

        if (curHp >= 10000)
        {

            curHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }
        if (maxHp >= 10000)
        {
            maxHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }


        coinHp.GetComponent<Text>().text = curString + '/' + maxString;
        if (hpBar)
            helthBar(curHp, maxHp);
    }
    public void CoinHpHUD(float curHp, float maxHp)
    {
        string curString = curHp.ToString("#.#");
        string maxString = maxHp.ToString("#.#");

        if (curHp >= 10000)
        {
            curHp /= 1000;
            curString = curHp.ToString("#.#") + 'K';
        }
        if (maxHp >= 10000)
        {
            maxHp /= 1000;
            maxString = curHp.ToString("#.#") + 'K';
        }


        coinHp.GetComponent<Text>().text = curString + '/' + maxString;
        if (hpBar)
            helthBar(curHp, maxHp);

    }

    private void CoinhelthBar(float curHP, float maxHp)
    {
        CoinhealthBar.GetComponent<Slider>().maxValue = maxHp;
        CoinhealthBar.GetComponent<Slider>().value = curHP;
    }
    private void COinhelthBar(int curHP, int maxHp)
    {
        CoinhealthBar.GetComponent<Slider>().maxValue = maxHp;
        CoinhealthBar.GetComponent<Slider>().value = curHP;
    }
    

    //Displays the amount of scraps are in the players envintory
    public void ScrapHUD(float scraps)
    {

        string scrapsString = scraps.ToString("#.#");

        if (scraps >= 10000)
        {
            scraps /= 1000;
            scrapsString = scraps.ToString("#.#") + 'K';
        }
        scrap.GetComponent<Text>().text = scrapsString;
    }
    public void ScrapHUD(int scraps)
    {

        string scrapsString = scraps.ToString("#.#");

        if (scraps >= 10000)
        {
            scraps /= 1000;
            scrapsString = scraps.ToString() + 'K';
        }
        scrap.GetComponent<Text>().text = scrapsString.ToString();
    }

    /*
    called in by the turret script to show the player how many turrets
    are on the playing field
    */ 
    //public void TurHUD(float tur)
    //{
    //    turrent.GetComponent<Text>().text = tur.ToString();
    //}
    public void TurHUD(int tur)
    {
        turrent.GetComponent<Text>().text = tur.ToString("#.#");
    }

    public void ChosenTurHUD(int tur)
    {
        curTurrent.GetComponent<Text>().text = tur.ToString("#.#");
    }
    

 
    ////////////////////////////////////////////////////////////////////////////////////
    




    /// <summary>
    /// Pass in a string to activate promp with that string. Pas in the same string will remove the promp;
    /// </summary>
    /// <param name="strng"></param>
    public void PrompDis(string strng)
    {
        //if its already active turn it off
        if (promp.activeSelf && promp.GetComponent<Text>().text == strng)
        { promp.SetActive(false); }
        //otherwise activate it
        else
        {
            if(!promp.activeSelf)
                promp.SetActive(true);

            promp.GetComponent<Text>().text = strng;
        }
        // Debug.Log("Settings");

    }
 

    /// <summary>
    /// 
    /// Changes the amount of logs displayed based on the number passed in
    /// 
    /// </summary>
    /// <param name="size"></param>
    public void NewLogSize(int size)
    {
        LogNodeNum = size;
        int oldLogSize = Log.Count;
        int newLogSize = size;
        int loopCounter;
        //if the old size is bigger then loop over the smaller size
        if (oldLogSize > newLogSize)
            loopCounter = newLogSize;
        else
            loopCounter = oldLogSize;

        List<GameObject> Temp = new List<GameObject>();
       

        for (int i = 0; i < loopCounter; i++)
            Temp.Add(Log[i]);
     
        Log.Clear();
        foreach (GameObject go in Temp)
            Log.Add(go);
       
       LogMake(newLogSize);
    }
    /// <summary>
    /// used for the EndEdit
    /// Creates the rest of the "Log Nodes" for the Log.
    /// </summary>
    /// <usedby>NewLogSize</usedby>
    /// <param name="size"></param>
    private void LogMake(int size)
    {
   
        if (Log.Count < size)
        {
          
            int dif = size - Log.Count;
            
            for(int i = 0; i < dif; i++ )
            {
                Vector3 vec3 = Log[Log.Count - 1].GetComponent<RectTransform>().localPosition;
                
                vec3.y += (Log[Log.Count - 1].GetComponent<RectTransform>().sizeDelta.y);
                
                Log.Add((GameObject)Instantiate(LogText, vec3, Log[Log.Count - 1].GetComponent<RectTransform>().localRotation));
                Log[Log.Count - 1].GetComponent<RectTransform>().transform.SetParent(Log[Log.Count - 2].GetComponent<RectTransform>().transform.parent);
                Log[Log.Count - 1].GetComponent<RectTransform>().transform.localPosition = vec3;
                Log[Log.Count - 1].GetComponent<Text>().text = "";
                
            }
        }
     
    }
    /// <summary>
    /// Pass in a String;
    /// Newest will be placed on the "Bottom" of the "HuD"
    /// </summary>
    /// <param name="strng"></param>
    public void LogUp(string strng)
    {

        while(strng.Length > 0)
        {
           int stringSize;
           if (strng.Length >= MaxCharInNodes)
               stringSize = MaxCharInNodes;
           else
               stringSize = strng.Length;


            for (int i = 0; i < Log.Count - 1; i++)
                Log[Log.Count - 1 - i].GetComponent<Text>().text = Log[Log.Count - 1 - i - 1].GetComponent<Text>().text;

            Log[0].GetComponent<Text>().text = strng.Substring(0, stringSize);


            strng = strng.Substring(stringSize);
        }
        
        
        //if (strng.Length > 10)
        //{
            
        //}



        
            //for (int i = 0; i < Log.Count - 1; i++)
            //    Log[Log.Count - 1 - i].GetComponent<Text>().text = Log[Log.Count - 1 - i - 1].GetComponent<Text>().text;

            //Log[0].GetComponent<Text>().text = strng;
        
    }
   
    /// <summary>
    /// GameObect "go" must be the InputField.
    /// Uses the LogUp fucntion to add what is typed in the InputField into the Log.
    /// </summary>
    /// <param name="go"> GameObect "go" must be the InputField. or have the Input Field Component</param>
    public void inputField(GameObject go)
    { 
        LogUp(go.GetComponent<InputField>().text);
        go.GetComponent<InputField>().text = "";
   
    }
    /// <summary>
    /// Used for the OnValueChange for the input field
    /// </summary>
    /// <param name="go"></param>
    public void inputFieldCheck(GameObject go)
    {
        if(go.GetComponent<InputField>().text.Length >= LogNodeNum * MaxCharInNodes)
        {
            go.GetComponent<InputField>().text = go.GetComponent<InputField>().text.Remove(go.GetComponent<InputField>().text.Length - 1);
        }
    }



     void Start()
     {  
     Log.Add(LogText);
     NewLogSize(5);
     }
     public void Awake()
     {
       //GUIManager.instance.SetState(promp, false);
     }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"> Lower Case</param>
    /// <param name="state"></param>
     public void SetState(string item, bool state)
     {
         switch (item)
         {
             case "menu": 
                 _menu.SetActive(state); 
                 break;
             case "start":
                 _start.SetActive(state);
                 break;
             case "finish":
                 _finish.SetActive(state);
                 break;
             case "panel":
                 _panel.SetActive(state);
                 break;
             default:
                 break;
         }
     }


    public void OnMenuPress()
    {
        if(_menu.activeSelf == true)
        HUDManager.instance.SetState("menu", false);

        else
        HUDManager.instance.SetState("menu", true);
    }

    public void SetInfoLeft(string t)
     {
         _info.text = t;
     }

 
     public GameObject _menu;
     public GameObject _start;
     public GameObject _finish; 
     public GameObject _panel;     
     public Text _info;
     

     [SerializeField]    GameObject hp;
     [SerializeField]    GameObject turrent;
     [SerializeField]    GameObject scrap;
     [SerializeField]    GameObject curTurrent;
     [SerializeField]    GameObject promp;
     [SerializeField]    GameObject healthBar;
     [SerializeField]    GameObject coinHp;
     [SerializeField]    GameObject CoinhealthBar;
   


     [SerializeField]    GameObject LogText;
     List<GameObject>    Log = new List<GameObject>();

     private int MaxCharInNodes = 40;
     private int LogNodeNum;


    [SerializeField]

    
    public  bool hpBar = true;
   /*
    * 994 559
    */

}
