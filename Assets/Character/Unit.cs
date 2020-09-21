using UnityEngine;

public abstract class Unit : ScriptableObject
{
    public string CharacterName;

    public int HP_Current;
    public int HP_Max;

    public APCore APCore { get; set; } = new APCore();

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