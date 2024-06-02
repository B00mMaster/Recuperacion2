using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button exitButton;
    public Button ControlButton;
    public GameObject controlPanel;
    
    //permite ir a la escena con el string especificado en el inspector
    public void LoadSceneGame(string Game)
    {
      
        SceneManager.LoadScene(Game);
    }


    private void Awake()
    {
        //mouse visible and manageablee
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //by clicking the buttons you access the functions
        exitButton.onClick.AddListener(Application.Quit);
        ControlButton.onClick.AddListener(ShowControls);
       
    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            HideControls();
        }

        
    }

    

    private void ShowControls()
    {
        //activate 
        controlPanel.SetActive(true);
    }

    private void HideControls()
    {
        //deactivate vision
        controlPanel.SetActive(false);
    }
}
