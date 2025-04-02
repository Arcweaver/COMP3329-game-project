public interface ISkill
{
    string GetSkillName();
    UnityEngine.Sprite GetIcon();
    float GetCooldownTime();
    float GetRemainingCooldown();
    bool IsOnCooldown();
    void Activate();
}