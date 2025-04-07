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
        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Don't get hit by spores: {!isHitBySpore}\n" +
            $"Don't let any fungus detonate automatically: {isNoSelfDetonateFungi}\n" +
            $"Spawn a fungus in each section of the arena: {fungiInEveryQuadrant}";
    }
}
