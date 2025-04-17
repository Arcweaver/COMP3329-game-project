using UnityEngine;

public class Lvl3_Purge_Skillshot : Skillshot
{
    //override to avoid unintended behaviour
    private void Start()
    {
    }

    void Update()
    {
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
    }

    void OnTriggerEnter2D(Collider2D obj)
    { }

    public override void Initialize(Vector3 dir, int affixValue, Skill skill, UnitTemplate userUnit)
    {
        unit = userUnit;
        direction = dir.normalized;
        affix = affixValue;
        sourceSkill = skill;
        
        // Initialize all child skillshot
        foreach(Transform child in gameObject.transform)
        {
            Skillshot childSkillshot = child.GetComponent<Skillshot>();
            childSkillshot.unit = userUnit;
        }
    }
}