public class Unit
{
    public string CharacterName { get; set; }

    public TargetTypes targetType { get; set; }

    public static Unit AllAllies()
    {
        return new Unit
        {
            CharacterName = "All Allies",
            targetType = TargetTypes.AllAllies
        };
    }

    public static Unit AllEnemies()
    {
        return new Unit
        {
            CharacterName = "All Enemies",
            targetType = TargetTypes.AllEnemies
        };
    }
}