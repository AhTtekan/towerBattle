using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    public Character[] Characters;

    private int selectedCharacterIndex;

    public Character SelectedCharacter
    {
        get
        {
            return Characters[selectedCharacterIndex];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Characters = new Character[]
        {
            new Character(){CharacterName = "Valdun" },
            new Character(){CharacterName = "Rettigar" },
            new Character(){CharacterName = "Noralis" },
            new Character(){CharacterName = "Cardione" },
        };
    }

    // Update is called once per frame
    void Update()
    {

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
