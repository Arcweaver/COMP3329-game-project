﻿using System.Threading;
using UnityEngine;

public class TrickstersGambitModifier : StatModifier
{
    public float damageBonus = 2f;

    public TrickstersGambitModifier(int affix)
    {
        //declare duration and stuff
        duration = 5;

        //timer
        timer = duration;

        // Effect
        effectPrefabPath = "Prefabs/AttackBuff";
        effectPrefab = Resources.Load<GameObject>(effectPrefabPath);
    }
   
    //declare stat change here
    public override void ApplyStatChange(UnitStat stat)
    {
        //might be better to get default value and apply bonus
        //this implementation can cause bonus to go out of control for multiple effects
        //it depends on multiplicative or additive bonus
        stat.damageDoneModifier *= (damageBonus/50) + 1;  //eq. to 1 + damageBonus/100）*2
        
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
