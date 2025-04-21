using UnityEngine;

public class Lvl3_ObjTracker : GameObjectiveTracker
{
    //tracker variables
    public int killGuardCount = 0;
    public bool isHealBoss = false;
    public bool isBishopExplode = false;

    private bool IsKillThreeGuard()
    {
        return killGuardCount >= 3;
    }

    public override string ParseObjectiveText()
    {
        int score = 0;
        string rating;
        if (IsKillThreeGuard()) score += 35;
        if (!isHealBoss) score += 20;
        if (!isBishopExplode) score += 20;
        score += player.currentHealth;

        switch (score)
        {
            case >= 141:
                rating = "S";
                break;
            case >= 120:
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

        return $"Player Hits: {playerHits}\n" +
            $"Player HP: {player.currentHealth}/{player.maxHealth}\n" +
            $"Kill 3 living guards/bishops within 10 sec: {IsKillThreeGuard()}\n" +
            $"No heal boss: {!isHealBoss}\n" +
            $"No exploding bishop: {!isBishopExplode}\n" +
            $"Rating: {rating}\n";
    }
}
