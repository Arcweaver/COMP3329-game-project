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

    public virtual void MoveTowardsPlayer(float min_distance, float spriteScale)
    {
        if (modifiedStats.moveSpeed != 0){
            if (player != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance < min_distance){return;}

                Vector3 direction = (player.position - transform.position).normalized;
                //Debug.Log($"Moving towards player at position: {player.position}");
                transform.position += modifiedStats.moveSpeed * Time.deltaTime * direction;

                //update sprite
                if (direction.x > 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(spriteScale, spriteScale);
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(-spriteScale, spriteScale);
                }
            }
            else
            {
                Debug.LogWarning("Player reference is null!");
            }
        }
    }

    public virtual void MoveTowardsPlayer(float min_distance)
    {
        MoveTowardsPlayer(min_distance, 1f);
    }

    public virtual void MoveTowardsPlayer()
    {
        MoveTowardsPlayer(0.0f);
    }

    public virtual void MoveTowards(float min_distance, float spriteScale, Transform obj)
    {
        if (modifiedStats.moveSpeed != 0){
            if (obj != null)
            {
                float distance = Vector3.Distance(obj.position, transform.position);
                if (distance < min_distance){return;}

                Vector3 direction = (obj.position - transform.position).normalized;
                //Debug.Log($"Moving towards player at position: {player.position}");
                transform.position += modifiedStats.moveSpeed * Time.deltaTime * direction;

                //update sprite
                if (direction.x > 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(spriteScale, spriteScale);
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(-spriteScale, spriteScale);
                }
            }
            else
            {
                Debug.LogWarning("obj reference is null!");
            }
        }
    }

}
