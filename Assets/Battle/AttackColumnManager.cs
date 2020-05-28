using System.Collections.Generic;
using UnityEngine;

public class AttackColumnManager : ColumnManager
{
    public override IEnumerable<string> GetNextColumnOptions()
    {
        return new List<string>() { "Attack" };
    }
}
