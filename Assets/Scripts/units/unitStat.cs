using UnityEngine;

public class UnitStat
{
    public float moveSpeed = 125f;
    public int maxHealth = 100;
    public int currentHealth;
    public float criticalChance = 0.2f; //0~1
    public float criticalModifier = 2f;
    public float damageTakenModifier = 1f;

    public void CopyStat(UnitTemplate u)
    {
        this.moveSpeed = u.moveSpeed;
        this.maxHealth = u.maxHealth;
        this.currentHealth = u.currentHealth;
        this.criticalChance = u.criticalChance;
        this.criticalModifier = u.criticalModifier;
    }
}
