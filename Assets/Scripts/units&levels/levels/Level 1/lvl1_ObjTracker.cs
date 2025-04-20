using System;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_ObjTracker : GameObjectiveTracker
{
    //tracker variables
    public bool isHitBySkill = false;

 

    public override string ParseObjectiveText()
    {
        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Don't get hit by any abilities: {!isHitBySkill}";
    }
}
