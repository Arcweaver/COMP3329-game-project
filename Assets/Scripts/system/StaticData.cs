using System;
using System.Collections.Generic;
using UnityEngine;

public class StaticData
{
    public static List<Skill> skills = new()
    {
        new FrostfireLanceSkill(),
        new QuicksilverSkill()
    };

    public static List<Skill> selectedSkills = new()
    {
        new(),
        new(),
        new(),
        new(),
    };
}
