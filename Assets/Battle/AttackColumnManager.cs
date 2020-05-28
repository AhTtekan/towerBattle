using System.Collections.Generic;
using UnityEngine;

public class AttackColumnManager : ColumnManager
{
    [SerializeField]
    private CanvasGroup nextColumnContent;

    public override CanvasGroup NextColumnContent
    {
        get
        {
            return nextColumnContent;
        }
    }

    public override IEnumerable<string> GetNextColumnOptions()
    {
        return new List<string>() { "Attack" };
    }
}
