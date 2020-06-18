using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Used for Column 3 Content generation
/// Column 3 content is Target Selection
/// Content will be based on column 2 selection (attack, defend, item, ability)
/// </summary>
public class GeneralColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        return AssociatedAction.TargetType.GetTargets()
            .Select(x => new TargetQueueable
            {
                Name = x.CharacterName,
                Target = x
            });
    }
}

public class TargetQueueable : IQueueable
{
    public string Name { get; set; }

    public int APCost => 0;

    public TargetTypes TargetType { get; set; }

    public Unit Target { get; set; }
}
