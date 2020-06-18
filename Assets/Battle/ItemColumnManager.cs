using System.Collections.Generic;

public class ItemColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        //TODO: Test data
        return new List<BattleItem>()
        {
            new BattleItem
            {
                Name = "Potion",
                TargetType = TargetTypes.Ally
            },
            new BattleItem
            {
                Name = "Hi Potion",
                TargetType = TargetTypes.Ally
            },
            new BattleItem
            {
                Name = "Elixir",
                TargetType = TargetTypes.Ally
            },
            new BattleItem
            {
                Name = "Phoenix Down",
                TargetType = TargetTypes.Ally
            },
            new BattleItem
            {
                Name = "Potion",
                TargetType = TargetTypes.Ally
            },
            new BattleItem
            {
                Name = "Fire Bomb",
                TargetType = TargetTypes.AllEnemies
            },
            new BattleItem
            {
                Name = "Restore",
                TargetType = TargetTypes.Ally
            },
        };
    }
}
