using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        // Press ANY button on Oculus controller
        if (OVRInput.GetDown(OVRInput.Button.Any))
        {
            SceneManager.LoadScene(2);
        }
    }
}