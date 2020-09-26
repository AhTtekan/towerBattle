using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleStateManager : MonoBehaviour
{
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable 0649
    [SerializeField]
    private BattleState[] battleStates;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Canvas selectionGuiCanvas;
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private CharacterManager characterManager;
    [SerializeField]
    private Button defaultSelectedButton;

    private BattleState currentState;

    void Start()
    {
        currentState = battleStates[0];
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State initialized to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");
    }

    //TODO: Debug crap here, remove
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var c = GameObject.FindObjectOfType<UIBattleSelectionManager>()._battleColumnController;

            Debug.Log($"Currently Selected Action: {c.GetColumnLastSelected(1).GetComponent<ColumnManager>().AssociatedAction.Name} " +
                $"being cast on {c.GetColumnLastSelected(2).GetComponent<ColumnManager>().AssociatedTarget.CharacterName}.");
        }
    }

    public void IncrementBattleState(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        currentState = currentState.nextState;
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State incremented to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");
    }

    public void DecrementBattleState(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        currentState = currentState.previousState;
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State decremented to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");
    }

    public void ActivateSelectionGUI(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        SetSelectionGUIActive(true);
    }

    public void DeactivateSelectionGUI(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        SetSelectionGUIActive(false);
    }

    public void SetSelectionGUIActive(bool active)
    {
        selectionGuiCanvas.gameObject.SetActive(active);
        eventSystem.gameObject.SetActive(active);
        if (active)
        {
            eventSystem.SetSelectedGameObject(defaultSelectedButton.gameObject);
            defaultSelectedButton.Select();
            eventSystem.SetSelectedGameObject(null);
        }
    }

    public void SetCharacterGUIActive(bool active)
    {
        var character = active ? characterManager.SelectedCharacter : ScriptableObject.CreateInstance<PartyMember>();
        foreach(var gui in GameObject.FindObjectsOfType<CharacterGUI>())
        {
            gui.Dim(character);
        }
    }
}
