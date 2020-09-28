using System;
using UnityEngine;

public abstract class Unit : ScriptableObject
{
    public string CharacterName;

    public int HP_Current;
    public int HP_Max;

    //TODO: Makes these show up in inspector: will need a customPropertyDrawer for it
    public APCore APCore { get; set; } = new APCore() { APBuildRateInSeconds = 10, AP_Max = 10 };

    public SpeedCore SpeedCore { get; set; } = new SpeedCore() { Agility = 25 };

    public virtual TargetTypes targetType { get; set; }

    public static Unit AllAllies()
    {
        var allAllies = CreateInstance<Unit>();

        allAllies.CharacterName = "All Allies";
        allAllies.targetType = TargetTypes.AllAllies;

        return allAllies;
    }

    public static Unit AllEnemies()
    {
        var allEnemies = CreateInstance<Unit>();

        allEnemies.CharacterName = "All Enemies";
        allEnemies.targetType = TargetTypes.AllEnemies;

        return allEnemies;
    }
}