using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public MainMenuSwitch menuSwitch; 

    public void OnButtonClicked()
    {
        Debug.Log("Button clicked! Using: " + menuSwitch.name);
        SceneManager.LoadScene("SampleScene 1"); 
    }
}   