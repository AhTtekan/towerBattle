﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BattleStateManager : MonoBehaviour
{
    [SerializeField]
    private BattleState[] battleStates;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Canvas selectionGuiCanvas;
    [SerializeField]
    private EventSystem eventSystem;

    private BattleState currentState;

    void Start()
    {
        currentState = battleStates[0];
        playerInput.SwitchCurrentActionMap(currentState.InputMapName);
        Debug.Log($"State initialized to {currentState.stateName}");
        Debug.Log($"Map: {playerInput.currentActionMap.name}");
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
    }
}
