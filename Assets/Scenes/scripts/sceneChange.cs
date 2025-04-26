using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChanger : MonoBehaviour
{
    public string SceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName); 
    }

    void OnMouseDown()
    {
        ChangeScene();
    }
}
