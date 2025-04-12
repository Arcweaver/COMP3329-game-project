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
        //unit.animator.SetBool("isSlam", false);
        //unit.animator.SetBool("isBite", false);
    }
}