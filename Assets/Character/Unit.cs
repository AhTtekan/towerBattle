using UnityEngine;

public abstract class Unit : ScriptableObject
{
    public string CharacterName;

    public int HP_Current;
    public int HP_Max;

    public APCore APCore;

    public SpeedCore SpeedCore;

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