using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "BattleState", menuName = "ScriptableObjects/Battle", order = 1)]
public class BattleState : ScriptableObject
{
    public string stateName;
    public InputActionAsset playerInput;
    public BattleState nextState;
    public BattleState previousState;
}
