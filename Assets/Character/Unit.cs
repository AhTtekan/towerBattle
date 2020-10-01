using System;
using UnityEngine;

public abstract class Unit : ScriptableObject
{
    public string CharacterName;

    public int HP_Current;
    public int HP_Max;

    public APCore APCore;// { get; set; } = new APCore() { APBuildRateInSeconds = 10, AP_Max = 10 };

    public SpeedCore SpeedCore;// { get; set; } = new SpeedCore() { Agility = 25 };

    public virtual TargetTypes targetType { get; set; }

    public static Unit AllAllies()
    {
        var allAllies = CreateInstance<Enemy>();

        allAllies.CharacterName = "All Allies";
        allAllies.targetType = TargetTypes.AllAllies;

        return allAllies;
    }

    public static Unit AllEnemies()
    {
        var allEnemies = CreateInstance<Enemy>();

        allEnemies.CharacterName = "All Enemies";
        allEnemies.targetType = TargetTypes.AllEnemies;

        return allEnemies;
    }
}