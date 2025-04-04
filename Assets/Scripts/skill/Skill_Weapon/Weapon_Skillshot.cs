using UnityEngine;

// template skillshot class
public class WeaponSkillshot : Skillshot
{
    void Start()
    {
        WeaponParentSkillshot parent = transform.parent.GetComponent<WeaponParentSkillshot>();
        unit = parent.unit;
        direction = parent.direction;
        sourceSkill = parent.sourceSkill;
    }

    void Update()
    {

    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), 10);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        GameObject collidedObject = obj.gameObject;
        // Example of how you might use the affix during collision
        if (collidedObject.CompareTag(opponentTag))
        {
            UnitTemplate enemy = collidedObject.GetComponent<UnitTemplate>();
            // collision/damange logic
            if (enemy != null)
            {
                SkillEffect(enemy);
                Debug.Log("Enemy damaged");
            }
            //apply stat modifier if applicable
        }
    }

}
