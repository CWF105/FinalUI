using UnityEngine;
using UnityEngine.UI;

public class debugger : MonoBehaviour
{
    public void OnClickDisplayInConsole(Button button)
    {
        Debug.Log(button.gameObject.name + " clicked and is working");
    }
}
