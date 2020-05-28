using System.Collections.Generic;
using UnityEngine;

public class DefendColumnManager : ColumnManager
{
    public override IEnumerable<string> GetNextColumnOptions()
    {
        return new[] { "Defend" };
    }
}
