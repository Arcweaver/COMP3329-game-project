public class Lvl3_Guard_Standstill_Modifier : StatModifier
{
    public float speedBonus = 2f;
    public string skillname;

    public Lvl3_Guard_Standstill_Modifier(float dura)
    {
        duration = dura;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= 0;
    }

    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat){}
    public override void ApplyExpirationChange(UnitTemplate unit)
    {
        //unit.animator.SetBool("isCast", false);
        //unit.animator.SetBool("isBite", false);
    }
}

public class Lvl3_Boss_Standstill_Modifier : StatModifier
{
    public float speedBonus = 2f;
    public string skillname;

    public Lvl3_Boss_Standstill_Modifier(float dura)
    {
        duration = dura;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= 0;
    }

    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat){}
    public override void ApplyExpirationChange(UnitTemplate unit)
    {
        unit.animator.SetBool("isCast", false);
    }
}

public class Lvl3_Guard_Speed_Modifer : StatModifier
{
    public float speedBonus = 2f;
    public string skillname;

    public Lvl3_Guard_Speed_Modifer(float dura)
    {
        duration = dura;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= speedBonus;
    }
}