using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementController : MonoBehaviour
{
    public PartyMember SelectedCharacter
    {
        get
        {
            return _characterManager.Characters[_selectedCharacterIndex];
        }
    }

    private CharacterManager _characterManager;
    private int _selectedCharacterIndex = 0;
    private int _characterCount;

    // Start is called before the first frame update
    void Start()
    {
        _characterManager = GameObject.FindObjectOfType<CharacterManager>();
        _characterCount = _characterManager.Characters.Length;
    }
    public void IncrementSelectedCharacter(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        MoveSelectedCharacter(true);
    }

    public void DecrementSelectedCharacter(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.started)
            return;
        MoveSelectedCharacter(false);
    }

    private void MoveSelectedCharacter(bool forward)
    {
        _selectedCharacterIndex =
            MathUtility.Wrap(
                forward ? _selectedCharacterIndex + 1 : _selectedCharacterIndex - 1,
                0,
                _characterCount - 1);
        Debug.Log($"Selected character moved to {SelectedCharacter.CharacterName} (index {_selectedCharacterIndex})");
    }
}
