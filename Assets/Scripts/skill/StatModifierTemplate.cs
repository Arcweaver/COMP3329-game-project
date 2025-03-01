using UnityEngine;

public class StatModifier
{
    public int healthModifier;
    public float speedModifier;
    public float duration = 0; // Duration for which the modifier is effective
    private float timer = 0; // Timer to track expiration


    // should have make player and enemy of the same parent :(
    // too lazy to fix it. :P
    public virtual void UpdateModifier(PlayerController owner)
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // Apply stat modifiers not involving damage to the owner
        //ApplyStatChange(owner);


        //if it is a damage over time, declare it here
        //owner.TakeDamage(1);

        // Check if the duration has expired
        if (timer <= 0)
        {
            // Remove modifier from the owner
            owner.RemoveModifier(this);
        }
    }

    public virtual void UpdateModifier(EnemyTemplate owner)
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // Apply the modifiers to the owner
        //ApplyStatChange(owner);


        //if it is a damage over time, declare it here
        //owner.TakeDamage(1);

        // Check if the duration has expired
        if (timer <= 0)
        {
            // Remove modifier from the owner
            owner.RemoveModifier(this);
        }
    }

    public virtual void ApplyStatChange(PlayerController owner)
    {

    }

    public bool IsExpired()
    {
        return timer <= 0;
    }
}
