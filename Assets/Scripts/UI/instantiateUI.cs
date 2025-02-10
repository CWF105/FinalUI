using UnityEngine;
using UnityEngine.UI;

public class instantiate : MonoBehaviour
{

    public GameObject windowPrefab;  
    private GameObject windowInstance;

    void Start() {
        windowInstance = Instantiate(windowPrefab);
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        windowInstance.transform.SetParent(canvasTransform, false);

        windowInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        windowInstance.transform.localScale = Vector3.one;
    }
    // public void OnButtonClick()
    // {
    //      if (windowInstance == null)
    //     {
    //         windowInstance = Instantiate(windowPrefab);
    //         Transform canvasTransform = GameObject.Find("Canvas").transform;
    //         windowInstance.transform.SetParent(canvasTransform, false);

    //         windowInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    //         windowInstance.transform.localScale = Vector3.one;

    //         Button closeButton = windowInstance.transform.Find("close btn").GetComponent<Button>();
    //         if (closeButton != null)
    //         {
    //             closeButton.onClick.AddListener(CloseWindow);
    //         }
    //         else
    //         {
    //             Debug.LogWarning("CloseButton not found in the window prefab!");
    //         }
    //     }
    // }

    private void CloseWindow()
    {
        if (windowInstance != null)
        {
            Destroy(windowInstance);
            windowInstance = null;
        }
    }
}