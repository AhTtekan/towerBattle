using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Inventory Inventory { get; set; }

    [SerializeField]
    public Character[] Characters;

    private int selectedCharacterIndex;

    public Character SelectedCharacter
    {
        get
        {
            if (Characters == null || Characters.Length == 0)
                throw new System.Exception("No characters loaded; unknown game state.");
            return Characters[selectedCharacterIndex];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Inventory = new Inventory();
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
        selectedCharacterIndex =
            MathUtility.Wrap(
                forward ? selectedCharacterIndex + 1 : selectedCharacterIndex - 1,
                0,
                Characters.Length - 1);
        Debug.Log($"Selected character moved to {SelectedCharacter.CharacterName} (index {selectedCharacterIndex})");
    }
}
