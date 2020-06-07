using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Character[] characters;

    private int selectedCharacterIndex;
    
    public Character SelectedCharacter
    {
        get
        {
            return characters[selectedCharacterIndex];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        characters = new Character[]
        {
            new Character(){CharacterName = "Test 1" },
            new Character(){CharacterName = "Test 2" },
            new Character(){CharacterName = "Test 3" },
            new Character(){CharacterName = "Test 4" },
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
                characters.Length - 1);
        Debug.Log($"Selected character moved to {SelectedCharacter.CharacterName} (index {selectedCharacterIndex})");
    }
}
