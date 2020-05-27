using System.Collections.Generic;
using UnityEngine;

public interface IColumnManager
{

    CanvasGroup NextColumnContent { get; }

    IEnumerable<string> GetNextColumnOptions();
}
