using System;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_ObjTracker : GameObjectiveTracker
{
    //tracker variables
    public bool isHitBySkill = false;

 

    public override string ParseObjectiveText()
    {
        // score and rating
        int score = 0;
        string rating;
        if (!isHitBySkill) score += 30;
        score += player.currentHealth;

        switch (score)
        {
            case >= 120:
                rating = "S";
                break;
            case >= 80:
                rating = "A";
                break;
            case >= 60:
                rating = "B";
                break;
            case >= 40:
                rating = "C";
                break;
            case >=20:
                rating = "D";
                break;
            default:
                rating = "D";
                break;

        }

        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Don't get hit by any abilities: {!isHitBySkill}\n" +
            $"Rating: {rating}\n";
    }
}
