using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour
{
    public void LoadSceneByName(string sceneName){SceneManager.LoadScene(sceneName);}
}
