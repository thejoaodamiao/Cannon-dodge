using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{


    

    private UImanager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    
   

    public void StartGame()
    {
        
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {

        SceneManager.LoadScene("Game over");
    }

   
}
