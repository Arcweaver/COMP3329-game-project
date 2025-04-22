using System;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_ObjTracker : GameObjectiveTracker
{
    //tracker variables
    public bool isHitBySpore = false;
    public bool isNoSelfDetonateFungi = true;
    public bool fungiInEveryQuadrant = false;
    private bool q1, q2, q3, q4 = false;

    public void CheckFungiInQuadrant(Vector3 pos)
    {
        if (fungiInEveryQuadrant) { return; }
        if (pos.x >= 0 && pos.y >= 0) { q1 = true; }
        else if (pos.x < 0 && pos.y >= 0) { q2 = true; }
        else if (pos.x < 0 && pos.y < 0) { q3 = true; }
        else if (pos.x >= 0 && pos.y < 0) { q4 = true; }
        if (q1 && q2 && q3 && q4)
        {
            fungiInEveryQuadrant = true;
        }
    }

    public override string ParseObjectiveText()
    {

        int score = 0;
        string rating;
        if (!isHitBySpore) score += 20;
        if (isNoSelfDetonateFungi) score += 20;
        if (fungiInEveryQuadrant) score += 30;
        score += player.currentHealth;

        switch (score)
        {
            case >= 150:
                rating = "S";
                break;
            case >= 130:
                rating = "A";
                break;
            case >= 100:
                rating = "B";
                break;
            case >= 70:
                rating = "C";
                break;
            default:
                rating = "D";
                break;

        }

        string ratingStr = player.currentHealth <= 0 ? "" : $"Rating: {rating}\n";

        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Don't get hit by spores: {!isHitBySpore}\n" +
            $"Don't let any fungus detonate automatically: {isNoSelfDetonateFungi}\n" +
            $"Spawn a fungus in each section of the arena: {fungiInEveryQuadrant}\n" +
            ratingStr;
    }
}
