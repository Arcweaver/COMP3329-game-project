using UnityEngine;

public class Lvl3_ObjTracker : GameObjectiveTracker
{
    //tracker variables
    public int killGuardCount = 0;

    private bool IsKillThreeGuard()
    {
        return killGuardCount >= 3;
    }

    public override string ParseObjectiveText()
    {
        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Kill 3 living guards/bishops within 10 sec: {IsKillThreeGuard()}\n";
    }
}
