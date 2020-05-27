using System.Collections.Generic;
using UnityEngine;

public class AttackColumnManager : MonoBehaviour, IColumnManager
{
    [SerializeField]
    private CanvasGroup nextColumnContent;

    public CanvasGroup NextColumnContent 
    { 
        get
        {
            return nextColumnContent;
        }
    }

    public IEnumerable<string> GetNextColumnOptions()
    {
        return new List<string>() { "Attack" };
    }

}
