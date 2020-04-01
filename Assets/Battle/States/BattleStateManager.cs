using UnityEngine;

public class BattleStateManager : MonoBehaviour
{
    [SerializeField]
    private BattleState[] battleStates;

    private BattleState currentState;

    void Start()
    {
        currentState = battleStates[0];
    }

    public void IncrementBattleState()
    {
        currentState = currentState.nextState;
    }

    public void DecrementBattleState()
    {
        currentState = currentState.previousState;
    }
}
