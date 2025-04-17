using UnityEngine;

public class Lvl3_HolyNova_Skillshot : Skillshot
{
    public int damage = 10;

    private void Start()
    {
        //skill speed
        speed = 100f;

        opponentTag = "Player";
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }

    private void GenerateSanctifiedGround()
    {   
        string skillshotPrefabPath = "Prefabs/lvl3HolyNovaGround";
        GameObject skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);
        GameObject skillshot = Instantiate(skillshotPrefab, transform.position, transform.rotation);
        Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
        if (skillshotComponent != null)
        {
            skillshotComponent.Initialize(direction, affix, null, unit);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    { 
        GameObject collidedObject = obj.gameObject;

        // Damage player
        if (collidedObject.CompareTag("Player"))
        {
            UnitTemplate playerUnit = collidedObject.GetComponent<UnitTemplate>();
            // collision/damange logic
            if (playerUnit != null)
            {
                Destroy(gameObject);
                SkillEffect(playerUnit);
                GenerateSanctifiedGround();
            }
        }
        else if (collidedObject.CompareTag("Enemy"))
        {
            Level3_Guard guardUnit = collidedObject.GetComponent<Level3_Guard>();
            Level3_Bishop bishopUnit = collidedObject.GetComponent<Level3_Bishop>();
            
            // Ignore alive bishop
            if (bishopUnit != null && bishopUnit.currentHealth > 0)
            {
                return;
            }
            // Speed buff or revive for guards
            else if (guardUnit != null)
            {
                Destroy(gameObject);
                guardUnit.Revive();
                guardUnit.ApplySpeedBuff();
                GenerateSanctifiedGround();
            }
        }
    }
}