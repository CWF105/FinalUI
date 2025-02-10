using UnityEngine;

public class hide_ui : MonoBehaviour
{
    public GameObject UI;
    public GameObject exitButton;

    void Start() {
        exitButton.SetActive(false);
    }

// HIDE UI
    public void hideUI() {
        UI.SetActive(false);
        exitButton.SetActive(true);
    }

// SHOW UI
    public void showUI() {
        exitButton.SetActive(false);
        UI.SetActive(true);
    }
}
