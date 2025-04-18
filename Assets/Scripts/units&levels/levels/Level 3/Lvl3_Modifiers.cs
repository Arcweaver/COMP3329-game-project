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
        unit.animator.SetBool("isAttack", false);
    }
}

public class Lvl3_Bishop_Standstill_Modifier : StatModifier
{
    public float speedBonus = 2f;
    public string skillname;

    public Lvl3_Bishop_Standstill_Modifier(float dura)
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
        unit.animator.SetBool("isAttack", false);
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
        unit.animator.SetBool("isAttack", false);
    }
}

public class Lvl3_Guard_Speed_Modifer : StatModifier
{
    public float speedBonus = 1.5f;
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

public class Lvl3_BlindingLight_Speed_Modifer : StatModifier
{
    public float speedBonus = 0.7f;
    public string skillname;

    public Lvl3_BlindingLight_Speed_Modifer(float dura)
    {
        duration = dura;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= speedBonus;
    }
}

public class Lvl3_IgnoreHolyNova_Modifer : StatModifier
{
    public Lvl3_IgnoreHolyNova_Modifer(float dura)
    {
        duration = dura;
        timer = duration;
    }
}