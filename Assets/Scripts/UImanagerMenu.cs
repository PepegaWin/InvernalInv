using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UImanagerMenu : MonoBehaviour
{

    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] Texture2D mouseTex;
    private AudioSource sc;

    private void Awake()
    {
        sc = GetComponent<AudioSource>();
        Cursor.SetCursor(mouseTex, Vector2.zero, CursorMode.Auto);
    }
    
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptionPanel()
    {
        menuPanel.SetActive(false);
        optionPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        optionPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
   
    public void  SetScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
