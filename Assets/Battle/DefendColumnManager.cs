using System.Collections.Generic;
using UnityEngine;

public class DefendColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        return new[] { ScriptableObject.CreateInstance<DefendAbility>() };
    }
}
