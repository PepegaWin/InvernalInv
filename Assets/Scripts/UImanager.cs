using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
    [SerializeField] TMP_Text[] writings;
    [SerializeField] GameObject player;
    [SerializeField] Texture2D cursorTex;
    private static int points;
    private static TMP_Text[] scoretext;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] TMP_Text score2text;
    public static void Add(int score)
    {
        points += score;
        foreach(TMP_Text t in scoretext){
            t.SetText(points.ToString());
        }
       
    }

    void Awake()
    {
        
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);
        scoretext = GetComponentInChildren<Canvas>().GetComponentsInChildren<TMP_Text>();
        writings = GetComponentInChildren<Canvas>().GetComponentsInChildren<TMP_Text>();
        
    }

   
    void Update()
    {
       
            if (CanDisplayTime())
            {
                TimeDisplay();
            }
        if (!player.activeSelf)
        {
            OpenGameOverPanel();
        }
        if (!gameOverPanel.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }


    public bool CanDisplayTime()
    {
 
        if (player.activeSelf)
        {
            return true;
        }
        return false;
    }


    void TimeDisplay()
    {
        float time = Time.time;
        writings[0].SetText("Time: " + ((int)time).ToString());
        writings[1].SetText("Score: " + points.ToString());
        score2text.SetText(writings[1].text);
    }

    void OpenGameOverPanel()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

   
    

    public void BackToMenu()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
