using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColumnManager : MonoBehaviour, IColumnManager
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
        return new[]
        {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"
        };
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
