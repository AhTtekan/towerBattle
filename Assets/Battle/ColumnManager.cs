using System.Collections.Generic;
using UnityEngine;

public abstract class ColumnManager : MonoBehaviour
{
    public abstract IEnumerable<IQueueable> GetNextColumnOptions();
}
