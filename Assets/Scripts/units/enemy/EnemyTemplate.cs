using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyTemplate : UnitTemplate
{
    //stats
    public Transform player; // player location
    //public List<GameObject> statModifier; //store stat modifiers


    void Update()
    {
        CallOnUpdate();
        HandleSkills();
    }
    

    public virtual void HandleSkills()
    {
        MoveTowardsPlayer();
    }

    public void MoveTowardsPlayer(float min_distance)
    {
        if (modifiedStats.moveSpeed != 0){
            if (player != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance < min_distance){return;}

                Vector3 direction = (player.position - transform.position).normalized;
                //Debug.Log($"Moving towards player at position: {player.position}");
                transform.position += modifiedStats.moveSpeed * Time.deltaTime * direction;
            }
            else
            {
                Debug.LogWarning("Player reference is null!");
            }
        }
    }

    public void MoveTowardsPlayer()
    {
        MoveTowardsPlayer(0.0f);
    }

}
