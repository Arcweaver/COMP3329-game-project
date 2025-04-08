using UnityEngine;

public class CombatParser
{
    public static void CombatParsing(UnitTemplate source, UnitStat sourceStat, int sourceHpChange, UnitTemplate target, UnitStat targetStat, int targetHpChange)
    {
        // to source
        if (source != null && sourceStat != null && sourceHpChange != 0)
        {
            bool isDamage = sourceHpChange > 0;
            bool isCritical = Random.Range(0f, 1f) <= sourceStat.criticalChance;
            float critModifier = isCritical ? sourceStat.criticalModifier : 1f;

            int hpChange = Mathf.FloorToInt(Mathf.Abs(sourceHpChange) * critModifier * sourceStat.damageTakenModifier);
            if (isDamage) {source.TakeDamage(hpChange);} else {source.Heal(hpChange);}
        }

        // to target, with source
        if (source != null && sourceStat != null && target != null && targetStat != null && targetHpChange != 0)
        {
            bool isDamage = targetHpChange > 0;
            bool isCritical = Random.Range(0f, 1f) <= sourceStat.criticalChance;
            float critModifier = isCritical ? sourceStat.criticalModifier : 1f;

            int hpChange = Mathf.FloorToInt(Mathf.Abs(targetHpChange) * critModifier * sourceStat.damageDoneModifier * targetStat.damageTakenModifier);
            //if (isDamage) { target.TakeDamage(hpChange); } else { target.Heal(hpChange); }
            if (isDamage)
            {
                target.TakeDamage(hpChange); // Apply damage to target

                // Check if source is Player and target is Boss
                if (source.CompareTag("Player") && target.CompareTag("Enemy"))
                {
                    GameObjectiveTracker tracker = Object.FindFirstObjectByType<GameObjectiveTracker>();
                    if (tracker != null)
                    {
                        tracker.PlayerHitsBoss(); // Record the hit
                        Debug.Log("Player hit the boss via CombatParser!");
                    }
                }
            }
            else
            {
                target.Heal(hpChange);
            }
        }

        //to target, without source
        //this cannot crit
        else if (target != null && targetStat != null && targetHpChange != 0)
        {
            bool isDamage = targetHpChange > 0;
            //no source: can't crit

            int hpChange = Mathf.FloorToInt(Mathf.Abs(targetHpChange) * targetStat.damageTakenModifier);
            if (isDamage) { target.TakeDamage(hpChange); } else { target.Heal(hpChange); }
        }
    }
}
