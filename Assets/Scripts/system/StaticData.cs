using System;
using System.Collections.Generic;
using UnityEngine;

public class StaticData
{
    public static List<Skill> skills = new()
    {
        new FrostfireLanceSkill(),
        new QuicksilverSkill(),
        new HolyJudgement(),
        new DragonCharge(),
        new TrickstersGambit(),
    };

    public static List<Skill> selectedSkills = new()
    {
        new HolyJudgement(),
        new DragonCharge(),
        new TrickstersGambit(),
        new QuicksilverSkill(),
    };
}
