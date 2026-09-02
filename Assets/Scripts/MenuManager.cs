// MenuManager.cs
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject gameRoot;

    public void PlayGame()
    {
        menuCanvas.SetActive(false);
        gameRoot.SetActive(true);
    }
}