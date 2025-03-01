using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BossTemplate : MonoBehaviour
{
    //stats
    public int bossMaxHp = 3000;
    public int bossCurrentHp = 3000;
    public Transform player; // player location
    public float moveSpeed = 120f; // boss movement speed
    public List<GameObject> statModifier; //store stat modifiers


    private void Update()
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
        bossCurrentHp -= damage;
        bossCurrentHp = Mathf.Clamp(bossCurrentHp, 0, bossMaxHp);
        Debug.Log($"Current Health: {bossCurrentHp}");
    }


    public virtual void Heal(int amount)
    {
        bossCurrentHp += amount;
        bossCurrentHp = Mathf.Clamp(bossCurrentHp, 0, bossMaxHp);
        Debug.Log($"Current Health: {bossCurrentHp}");
    }
}