using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    public Character[] Characters;

    public Sprite[] characterSprites;

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
            new Character(){CharacterName = "Valdun", HP_Max = 150, HP_Current = 150, characterSprite = characterSprites[0] },
            new Character(){CharacterName = "Rettigar", HP_Max = 200, HP_Current = 200, characterSprite = characterSprites[1] },
            new Character(){CharacterName = "Noralis", HP_Max = 130, HP_Current = 130, characterSprite = characterSprites[2] },
            new Character(){CharacterName = "Cardione", HP_Max = 100, HP_Current = 100, characterSprite = characterSprites[3] },
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
