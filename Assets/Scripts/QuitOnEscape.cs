using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOnEscape : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Quit();
        }
    }
}