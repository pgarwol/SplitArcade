using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Ready : MonoBehaviour, ISelectHandler, IDeselectHandler {
    private Button button;
    private Text buttonText;

    public string selectedText;
    public string deselectedText;

    void Start() {
        selectedText = "Selected";
        deselectedText = "Deselected";

        button = GetComponent<Button>();
        //buttonText = button.GetComponentInChildren<Text>();
        buttonText = button.GetComponentInChildren<Text>();
    }

    public void OnSelect(BaseEventData eventData) {
        // Change the button text when it is selected
        buttonText.text = selectedText;
    }

    public void OnDeselect(BaseEventData eventData) {
        // Change the button text when it is deselected
        buttonText.text = deselectedText;
    }
}