using UnityEngine;
using UnityEngine.UI;

public class buttonHandler : MonoBehaviour
{
    public Button thisButton; // Drag the same button here in the Inspector

    public void HideMe()
    {
        thisButton.gameObject.SetActive(false);
    }
}   