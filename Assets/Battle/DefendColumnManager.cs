using System.Collections.Generic;
using UnityEngine;

public class DefendColumnManager : ColumnManager
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
        return new[] { "Defend" };
    }
}
