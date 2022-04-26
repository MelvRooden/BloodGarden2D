using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
    public Text inputText;

    public bool IsActive => gameObject.active;

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.active);
    }

    public void SetInputText (string input)
    {
        inputText.text = input;
    }
}
