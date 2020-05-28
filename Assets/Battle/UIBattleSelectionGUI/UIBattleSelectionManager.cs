using System.Linq;
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
    private CanvasGroup Column2Content;
    [SerializeField]
    private CanvasGroup Column1Content;
    [SerializeField]
    private Button GUIButtonPrefab;
#pragma warning restore 0649

    private BattleColumnMovementController _battleColumnController;

    public UnityEvent UIPopulateColumn;

    void Awake()
    {
        _battleColumnController = new BattleColumnMovementController(Column1Content, Column2Content, null);
    }

    public void PopulateNextColumn()
    {
        //Column2Content.transform.DestroyAllChildren();

        var columnManager = _battleColumnController
            .GetColumnLastSelected(_battleColumnController.index)?
            .GetComponent<ColumnManager>();

        columnManager.NextColumnContent.transform.DestroyAllChildren();

        var texts = columnManager.GetNextColumnOptions().ToArray();

        for (int i = 0; i < texts.Count(); i++)
        {
            GenerateNewButton(i, texts[i]);
        }

        _battleColumnController.Forward();

        UIPopulateColumn.Invoke();
    }

    public void PopulateColumn2WithTest()
    {
        PopulateColumn2WithTestData();
        _battleColumnController.Forward();
    }

    public void SetColumn1LastSelected(Button button)
    {
        _battleColumnController.SetColumnLastSelected(0, button);
    }

    public void Back(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed)
            return;
        _battleColumnController.Back();
    }

    private void PopulateColumn2WithTestData()
    {
        Column2Content.transform.DestroyAllChildren();

        for (int i = 0; i < UnityEngine.Random.Range(4, 10); i++)
        {
            GenerateNewButton(i, "Test");
        }

        UIPopulateColumn.Invoke();
    }

    private RectTransform GenerateNewButton(int i, string text)
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
        button.SetParent(Column2Content.transform, false);
        entry.callback.AddListener((eventData) => { button.parent.parent.parent.GetComponent<UIUpdateFunctions>().Scroll(); });
        button.anchoredPosition = new Vector2(button.anchoredPosition.x, button.sizeDelta.y * -i);

        var textObj = button.GetComponentInChildren<TextMeshProUGUI>();
        textObj.text = text;

        return button;
    }
}
