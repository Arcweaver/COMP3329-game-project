using UnityEngine;

// template skillshot class
public class WeaponParentSkillshot : Skillshot
{
    private float playerToMouseAngle;
    private float startAngle;
    private float endAngle;
    private float angle;

    void Start()
    {
        playerToMouseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(playerToMouseAngle);
        startAngle = playerToMouseAngle + 30;
        endAngle = playerToMouseAngle - 30;
        angle = startAngle;
    }

    void Update()
    {
        transform.position = unit.transform.position;
        // Calculate the angle based on the movement direction
        angle -= 160f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle <= endAngle) Destroy(gameObject, 0.1f);
    }

    public override void Initialize(Vector3 dir, int affixValue, Skill skill, UnitTemplate userUnit)
    {
        unit = userUnit;
        direction = dir.normalized;
        affix = affixValue;
        sourceSkill = skill;
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), 100);
    }

}
