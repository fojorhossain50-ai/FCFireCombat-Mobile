using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacterIndex = 0;

    void Start()
    {
        UpdateCharacterVisibility();
    }

    public void NextCharacter()
    {
        characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex = (selectedCharacterIndex + 1) % characters.Length;
        UpdateCharacterVisibility();
    }

    private void UpdateCharacterVisibility()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == selectedCharacterIndex);
        }
    }
}
