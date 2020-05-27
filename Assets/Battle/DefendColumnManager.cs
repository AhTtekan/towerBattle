using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendColumnManager : MonoBehaviour, IColumnManager
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
        return new[] { "Defend" };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
