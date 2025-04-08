using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int sceneId;

    public void LoadSceneF()
    {
        SceneManager.LoadScene(sceneId);
    }
}
