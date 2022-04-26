using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
    [SerializeField]
    private Text inputText;

    public bool IsActive => gameObject.activeSelf;

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetInputText (string input)
    {
        inputText.text = input;
    }
}
