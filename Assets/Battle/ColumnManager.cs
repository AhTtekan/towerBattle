using System.Collections.Generic;
using UnityEngine;

public abstract class ColumnManager : MonoBehaviour
{

    public abstract CanvasGroup NextColumnContent { get; }

    public abstract IEnumerable<string> GetNextColumnOptions();
}
