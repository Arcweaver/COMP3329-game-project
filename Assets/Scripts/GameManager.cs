using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
    {
        //// Subscribe to the events
        //playerController.OnSkillCast += HandleSkillCast;
        //playerController.OnBasicAttack += HandleBasicAttack;
    }

    private void HandleSkillCast(int skillNumber)
    {
        Debug.Log($"Skill {skillNumber} was cast!");
        // Add any additional logic for handling skill casting here
    }

    private void HandleBasicAttack()
    {
        Debug.Log("Basic Attack event handled!");
        // Add any additional logic for handling basic attacks here
    }
}
