using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleColumnMovementController
{
    public Column[] Columns { get; set; }

    private int index;
    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            if (value < 0)
                index = 0;
            else if (value > Columns.Length - 1)
                index = Columns.Length - 1;
            else
                index = value;
        }
    }

    public bool IsFirstColumn()
    {
        return index == 0;
    }

    public bool IsLastColumn()
    {
        return index == Columns.Length - 1;
    }

    /// <summary>
    /// Constructor for BattleColumnMovementController
    /// </summary>
    /// <param name="canvasGroups">canvasGroups for each column stored in index order referring to the Content gameobject under Viewport</param>
    public BattleColumnMovementController(params CanvasGroup[] canvasGroups)
    {
        Columns = canvasGroups.Select(x => new Column { ContentBox = x }).ToArray();

    }

    public void Back()
    {
        Back(true);
    }

    public void Back(bool clearOldContent)
    {
        if (Index == 0)
            return; //TODO: Changed state
        Index--;
        var column = Columns[Index];
        if (column.LastSelectedButton != null)
        {
            if (clearOldContent)
                ClearColumn(Index + 1);
            column.ContentBox.interactable = true;
            Columns[Index + 1].ContentBox.interactable = false;
            column.LastSelectedButton.Select();
            column.LastSelectedButton.GetComponent<IUIAccentuate>().ResetAccent();
            column.LastSelectedButton = null;
        }
    }

    public void Forward()
    {
        if (Index == Columns.Length)
            return; //TODO: Changed state
        Index++;

        Columns[Index].ContentBox.interactable = true;
        var previousColumn = Columns[Index - 1];
        previousColumn.ContentBox.interactable = false;

        Columns[Index].ContentBox.GetComponent<UIAutoResizeContent>().UpdateHeightFromChildrenHeight();

        //Columns[index].ContentBox.transform.GetChild(0).GetComponent<Button>().Select(); //This doesn't seem to work consistently, using EvenSystem.SetSelectedGameObject call instead.
        if (EventSystem.current != null && Columns[Index].ContentBox.transform.childCount > 0)
            EventSystem.current.SetSelectedGameObject(Columns[Index].ContentBox.transform.GetChild(0).gameObject);
    }

    public void SetColumnLastSelected(int columnIndex, Button button)
    {
        Columns[columnIndex].LastSelectedButton = button;
    }

    public Button GetColumnLastSelected(int columnIndex)
    {
        return Columns[columnIndex].LastSelectedButton;
    }

    private void ClearColumn(int columnIndex)
    {
        Columns[columnIndex].ContentBox.transform.DestroyAllChildren();
    }

    public struct Column
    {
        public CanvasGroup ContentBox;
        public Button LastSelectedButton;
    }
}
