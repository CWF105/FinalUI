using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ModalManager : MonoBehaviour
{
    private List<GameObject> activeModals = new List<GameObject>(); // Track multiple modals

    public void OpenModal(GameObject modalPrefab)
    {
        GameObject newModal = Instantiate(modalPrefab, transform); // Instantiate under Canvas
        newModal.transform.SetAsLastSibling(); // Ensure it's on top
        activeModals.Add(newModal); // Add to the active modals list

        // Find CloseButton in the newly instantiated modal and add event
        Button closeButton = newModal.transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(() => CloseModal(newModal)); // Pass modal reference
    }

    public void CloseModal(GameObject modal)
    {
        if (activeModals.Contains(modal))
        {
            activeModals.Remove(modal);
            Destroy(modal);
        }
    }
}
