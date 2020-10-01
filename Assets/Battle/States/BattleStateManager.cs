using System;
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
    private APRateCalculator[] _calculators;

    void Start()
    {
        currentState = battleStates[0];
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State initialized to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");
        StartCalculators();
        SetStartingAP();
    }

    private void SetStartingAP()
    {
        //TODO: Possible addition of states where battle starts with characters at more than 0?

        foreach (var character in characterManager.Characters)
            character.APCore.AP_Current = 0;
    }

    private void StartCalculators()
    {
        _calculators = new APRateCalculator[characterManager.Characters.Length];

        int i = 0;
        foreach (var character in characterManager.Characters)
        {
            _calculators[i] = new APRateCalculator(character.APCore, character.SpeedCore, !currentState.BuildAP);

            StartCoroutine(_calculators[i].Increment());

            i++;
        }
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

        SetCalculators();
    }

    public void DecrementBattleState(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        currentState = currentState.previousState;
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State decremented to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");

        SetCalculators();
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
        foreach (var gui in GameObject.FindObjectsOfType<CharacterGUI>())
        {
            gui.Dim(character);
        }
    }

    private void SetCalculators()
    {
        foreach (var calc in _calculators)
        {
            calc.Kill(!currentState.BuildAP);
        }
    }

}
