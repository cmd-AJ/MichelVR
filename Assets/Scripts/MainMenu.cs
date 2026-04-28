using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Select5()
    {
        SceneManager.LoadScene(1);
    }
    public void Select10()
    {
        SceneManager.LoadScene(2);
    }
    public void Select15()
    {
        SceneManager.LoadScene(3);
    }
    public void Select20()
    {
        SceneManager.LoadScene(4);
    }
    public void Select25()
    {
        SceneManager.LoadScene(5);
    }
    public void Select30()
    {
        SceneManager.LoadScene(6);
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
