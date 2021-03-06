﻿using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIBattleSelectionManager : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    private CanvasGroup[] ColumnContents;
    [SerializeField]
    private Button GUIButtonPrefab;
    [SerializeField]
    private BattleStateManager battleStateManager;
#pragma warning restore 0649

    //TODO: Make this private again
    public BattleColumnMovementController _battleColumnController;

    public UnityEvent UIPopulateColumn;

    void Awake()
    {
        _battleColumnController = new BattleColumnMovementController(ColumnContents);
    }

    public void PopulateNextColumn()
    {
        if (_battleColumnController.IsLastColumn())
            return;

        var columnManager = _battleColumnController
            .GetColumnLastSelected(_battleColumnController.Index)?
            .GetComponent<ColumnManager>();

        _battleColumnController.Columns[_battleColumnController.Index + 1].ContentBox.transform.DestroyAllChildren();

        var texts = columnManager.GetNextColumnOptions().ToArray();

        for (int i = 0; i < texts.Count(); i++)
        {
            GenerateNewButton(i, texts[i], _battleColumnController.Columns[_battleColumnController.Index + 1].ContentBox.transform);
        }

        _battleColumnController.Forward();

        UIPopulateColumn.Invoke();
    }

    public void SetColumnLastSelected(Button button)
    {
        _battleColumnController.SetColumnLastSelected(_battleColumnController.Index, button);
    }

    public void Back(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        if (!_battleColumnController.Back())
        {
            battleStateManager.DecrementBattleState(callbackContext);
            battleStateManager.SetSelectionGUIActive(false);
        }
    }

    private RectTransform GenerateNewButton(int i, IQueueable queueable, Transform contentBox)
    {
        RectTransform button = GameObject.Instantiate(GUIButtonPrefab).GetComponent<RectTransform>();
        EventTrigger trigger = button.GetComponent<EventTrigger>();
        if (trigger.triggers == null)
            trigger.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();
        EventTrigger.Entry entry = trigger.triggers.FirstOrDefault(x => x.eventID == EventTriggerType.Select);// new EventTrigger.Entry();
        if (entry == null)
        {
            entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.Select
            };
            trigger.triggers.Add(entry);
        }
        button.SetParent(contentBox, false);
        entry.callback.AddListener((eventData) => { button.parent.parent.parent.GetComponent<UIUpdateFunctions>().Scroll(); });
        button.anchoredPosition = new Vector2(button.anchoredPosition.x, button.sizeDelta.y * -i);

        var textObj = button.GetComponentInChildren<TextMeshProUGUI>();
        textObj.text = queueable.Name;

        var columnManager = button.GetComponent<ColumnManager>();
        columnManager.AssociatedAction = queueable;

        if (queueable is TargetQueueable)
        {
            columnManager.AssociatedTarget = ((TargetQueueable)queueable).Target;
        }

        return button;
    }
}
