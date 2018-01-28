using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneToSwitchTo;

    public void Switch()
    {
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
