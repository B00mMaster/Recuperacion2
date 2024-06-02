using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnMenu : MonoBehaviour
{
    //go to scene menu
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
