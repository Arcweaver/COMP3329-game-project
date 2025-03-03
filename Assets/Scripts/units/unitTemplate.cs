using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class UnitTemplate : MonoBehaviour
{
    //default values
    public float moveSpeed = 125f; 
    public int maxHealth = 100;
    public int currentHealth;
    public float criticalChance = 0.2f; //0~1
    public float criticalModifier = 2f;
    public float damageTakenModifier = 1f;

    public List<StatModifier> activeModifiers = new();
    public UnitStat modifiedStats = new();

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        CallOnUpdate();
    }

    //call this on all unit update
    public void CallOnUpdate()
    {
        modifiedStats.CopyStat(this);
        UpdateModifiers(this);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }


    public virtual void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }

    
    

    //stat modifer functions
    public virtual UnitStat GetDefaultStats()
    {
        UnitStat s = new UnitStat();
        s.CopyStat(this);
        return s;
    }
   
    public UnitStat GetModifiedStats()
    {
        modifiedStats.CopyStat(this);
        for (int i = 0; i < activeModifiers.Count; i++)
        {
            StatModifier modifier = activeModifiers[i];
            modifier.ApplyStatChange(modifiedStats);

            //the modifier should remove itself in UpdateModifier
            if (modifier.IsExpired())
            {
                // If the modifier is expired, remove it
                RemoveModifier(modifier);
            }
        }
        return modifiedStats;
    }


    //call in update
    //puts stat modifications into a temp nit s
    //apply the changes via ApplyStatChange()
    public void UpdateModifiers(UnitTemplate u)
    {
        modifiedStats.CopyStat(this);
        for (int i = 0; i < activeModifiers.Count; i++)
        {
            StatModifier modifier = activeModifiers[i];
            modifier.UpdateModifier(u, modifiedStats);  //should update it in a copy of stat in order to preserve original stat

            
            if (modifier.IsExpired())
            {
                RemoveModifier(modifier);
            }
        }
    }


    public void AddModifier(StatModifier modifier)
    {
        activeModifiers.Add(modifier);
        Debug.Log(activeModifiers.Count);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        activeModifiers.Remove(modifier);
        Debug.Log(activeModifiers.Count);
    }

    
}







