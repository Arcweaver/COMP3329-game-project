using System.Threading;
using UnityEngine;

public class HolyJudgementModifier : StatModifier
{
    public float critBonus = 1f;

    public HolyJudgementModifier(int affix)
    {
        //declare duration and stuff
        duration = 0.5f;

        //timer
        timer = duration;
    }
   
    //declare stat change here
    public override void ApplyStatChange(UnitStat stat)
    {
        //might be better to get default value and apply bonus
        //this implementation can cause bonus to go out of control for multiple effects
        //it depends on multiplicative or additive bonus
        stat.moveSpeed += critBonus;
    }

    //changes that only happen on update (eg. damage over time)
    //should not apply timer expiration here
    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat)
    {
    }
    
    

    //changes on expiration excluding removal of modifier
    public override void ApplyExpirationChange(UnitTemplate unit)
    {
    }
}
