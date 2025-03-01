using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyTemplate : MonoBehaviour
{
    //stats
    public int maxHp = 3000;
    public int currentHp = 3000;
    public Transform player; // player location
    public float moveSpeed = 120f; // boss movement speed
    public List<GameObject> statModifier; //store stat modifiers


    void Update()
    {
        HandleSkills();
    }
    

    public virtual void HandleSkills()
    {
        MoveTowardsPlayer();
    }

    public void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            //Debug.Log($"Moving towards player at position: {player.position}");
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("Player reference is null!");
        }
    }



    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        Debug.Log($"Current Health: {currentHp}");
    }


    public virtual void Heal(int amount)
    {
        currentHp += amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        Debug.Log($"Current Health: {currentHp}");
    }
}