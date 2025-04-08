using UnityEngine;

//acts mainly as a carrier class
public class UnitStat
{
    public float moveSpeed = 125f;
    public int maxHealth = 100;
    public int currentHealth;
    public float criticalChance = 0.2f; //0~1
    public float criticalModifier = 2f;
    public float damageTakenModifier = 1f;
    public float damageDoneModifier = 1f;

    //you may introduce more variable here if needed

    //copy the important, universal stat
    public void CopyStat(UnitTemplate u)
    {
        this.moveSpeed = u.moveSpeed;
        this.maxHealth = u.maxHealth;
        this.currentHealth = u.currentHealth;
        this.criticalChance = u.criticalChance;
        this.criticalModifier = u.criticalModifier;
        this.damageTakenModifier = u.damageTakenModifier;
        this.damageDoneModifier = u.damageDoneModifier;
    }
}
