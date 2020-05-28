using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private UIBattleSelectionManager _uiBattleSelectionManager;

    public void Start()
    {
        _uiBattleSelectionManager = GameObject.FindObjectOfType<UIBattleSelectionManager>();
    }

    public void SetupNextColumnSwitch()
    {
        SetPreviousColumnSelected();

        PopulateNextColumn();
    }

    public void SetPreviousColumnSelected()
    {
        _uiBattleSelectionManager.SetColumn1LastSelected(gameObject.GetComponent<Button>());
    }

    public void PopulateNextColumn()
    {
        _uiBattleSelectionManager.PopulateNextColumn();
    }
}
