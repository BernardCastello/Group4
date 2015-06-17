using UnityEngine;
using System.Collections;

public class ScoreManager : Singleton<ScoreManager>
{
  
    
    /// <summary>
    /// Pass in 2 variables. The first is the Current Health the second is The max Health.
    /// If Current Health is greater then the max it will be changed to max health.
    /// </summary>
    /// <param name="curHp"></param>
    /// <param name="maxHp"></param>
    /// <returns>True if Health is not less then 0</returns>
    public bool Hp(float curHp, float maxHp)
    {
        if (curHp > maxHp)
            curHp = maxHp;
        else if (curHp <= 0) { return false; }
        //Use GM to trigger Lose State

        //HUDManager.instance.HpHUD(curHp, maxHp);
        return true;
    }
    /// <summary>
    /// Pass in 2 variables. The first is the Current Health the second is The max Health.
    /// If Current Health is greater then the max it will be changed to max health.
    /// 
    /// Note: if current hp is less then or equal to 0 it will terminate the application
    ///        based on the GameManager. "GameManager Needed"
    /// 
    /// </summary>
    /// <param name="curHp"></param>
    /// <param name="maxHp"></param>
    /// <returns>True if Health is not less then 0 or equal to 0</returns>
    public bool Hp(int curHp, int maxHp)
    {
        if (curHp > maxHp)
            curHp = maxHp;
        else if (curHp <= 0) { return false; }
        //Use GM to trigger Lose State

        HUDManager.instance.HpHUD(curHp, maxHp);
        return true;
    }
    /// <summary>
    /// Pass in 1 Variable. The variable will be the number of Scraps(Currency). 
    /// It will measure the amount as a bool. 
    /// 
    /// Note: Make sure to cancel action bool returns False.
    /// 
    /// </summary>
    /// <param name="scrapCount"></param>
    /// <returns>False if the number is less then or equal to 0 
    ///          and true if the number is greater then 0</returns>
    public bool Scrap(float scrapCount)
    {
        if (scrapCount < 0)
        { return false; }

        HUDManager.instance.ScrapHUD(scrapCount);
        return true;
    }
    /// <summary>
    /// Pass in 1 Variable. The variable will be the number of Scraps(Currency). 
    /// It will measure the amount as a bool. 
    /// 
    /// Note: Make sure to cancel action bool returns False.
    /// 
    /// </summary>
    /// <param name="scrapCount"></param>
    /// <returns>False if the number is less then or equal to 0 
    ///          and true if the number is greater then 0</returns>
    public bool Scrap(int scrapCount)
    {
        if (scrapCount < 0)
        { return false; }

        HUDManager.instance.ScrapHUD(scrapCount);
        return true;
    }
    public bool SpecialScrap(float scrapCount)
    {
        if (scrapCount < 0)
        { return false; }

        
        return true;

    }
    public bool SpecialScrap(int scrapCount)
    {
        if (scrapCount < 0)
        { return false; }

        return true;

    }
    /// <summary>
    /// 
    /// Pass in 1 Variable. The Variable will be the number of turrets placed.
    /// 
    /// Note: Make sure to cancel action bool returns False.
    /// 
    /// </summary>
    /// <param name="turretNumber"></param>
    /// <returns> Returns true so long as number of turrets is more then 0 </returns>
    public bool Turret(float turretNumber)
    {
        if (turretNumber < 0)
            return false;

        //HUDManager.instance.CurTur(turretNumber);
        return true;
    }
    /// <summary>
    /// 
    /// Pass in 1 Variable. The Variable will be the number of turrets placed.
    /// 
    /// Note: Make sure to cancel action bool returns False.
    /// 
    /// </summary>
    /// <param name="turretNumber"></param>
    /// <returns> Returns true so long as number of turrets is more then 0 </returns>
    public bool Turret(int turretNumber)
    {
        if (turretNumber < 0)
            return false;

        HUDManager.instance.TurHUD(turretNumber);
        return true;
    }
}
