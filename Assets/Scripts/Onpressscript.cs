using UnityEngine;
using UnityEngine.SceneManagement;

public class Onpressscript : MonoBehaviour
{

    public int sceneToLoad = 2; // Set this to the index of the scene you want to load

    void Update()
    {
        // Press ANY button on Oculus controller
        if (OVRInput.GetDown(OVRInput.Button.Any))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

//