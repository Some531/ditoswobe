using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSwitch : ScriptableObject

{
    public MainMenuSwitch menuSwitch;

    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("level_1"); 
    }
}   
