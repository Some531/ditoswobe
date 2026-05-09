using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public MainMenuSwitch menuSwitch; 

    public void OnButtonClicked()
    {
        SceneManager.LoadScene("level_1"); 
    }
}   