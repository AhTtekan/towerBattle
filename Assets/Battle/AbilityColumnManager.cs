﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityColumnManager : MonoBehaviour, IColumnManager
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
            "Test 1",
            "Test 2",
            "Test 3",
            "Test 4",
            "Test 5",
            "Test 6",
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
