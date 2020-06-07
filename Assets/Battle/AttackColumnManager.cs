using System.Collections.Generic;
using UnityEngine;

public class AttackColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        return new List<AttackAbility>() { new AttackAbility() };
    }
}
