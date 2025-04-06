using UnityEngine;

public class StatModifier
{
    //declare variables to help with stat changes
    //eg.
    //public int healthModifier;
    //public float speedModifier;
    public float duration = 0; // Duration for which the modifier is effective
    public float timer = 0; // Timer to track expiration
    public string effectPrefabPath; // Buff effect path
    public GameObject effectPrefab; // Buff effect prefab
    public GameObject effectObject; // Buff effect object
    public int affix = 0;

    public virtual void StartModifier()
    {
        timer = duration;
    }

    //monitors the flow of application and expiration of the modifier
    //this should be called in the update modifier method in the unit, which should have been handled in the template
    public void UpdateModifier(UnitTemplate unit, UnitStat stat)
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // Apply stat modifiers not involving damage to the owner
        ApplyStatChange(stat);

        //if it is a damage over time, declare it here
        ApplyChangeOnUpdate(unit, stat);

        // Check if the duration has expired
        if (IsExpired())
        {
            ApplyExpirationChange(unit);
        }
    }

   
    //declare stat change here
    public virtual void ApplyStatChange(UnitStat stat)
    {
        //stat.moveSpeed += speedModifier;
    }

    //changes that only happen on update 
    //eg. damage over time
    //should not apply timer expiration here
    public virtual void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat)
    {
        //unit.TakeDamage(1);
    }
    
    //check expiration condition
    public virtual bool IsExpired()
    {
        return timer <= 0;
    }

    //changes on expiration excluding removal of modifier
    public virtual void ApplyExpirationChange(UnitTemplate unit)
    {
        
    }

    // Apply the buff effect to user
    public virtual void ApplyEffect(UnitTemplate unit)
    {
        if (effectPrefab != null)
        {
            effectObject = Object.Instantiate(effectPrefab, unit.transform);
        }
    }
}
