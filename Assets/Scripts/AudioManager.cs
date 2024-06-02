using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;

    public AudioClip menu, game, gameOver, skScream, shoot, reload,swing,youWin;
    public AudioClip[] playerScream;

    private void Start()
    {
        music.clip = game;
        music.Play();
        //depending on the scene different music will be activated
        if (SceneManager.GetActiveScene().name=="Menu")
        {
            music.clip = menu;
            music.Play();
        }

        if(SceneManager.GetActiveScene().name=="GameOver")
        {
            music.clip = gameOver;
            music.Play();
        }
        
        if (SceneManager.GetActiveScene().name == "YouWin")
        {

            Invoke("YouWin", 3f);

           
        }

       
    }
  
    void YouWin()
    {
        music.clip = youWin;
        music.Play();
      
    }
    void Menu()
    {

    }



    public void PlaySFX(AudioClip sfx)
    {
        SFX.PlayOneShot(sfx);
    }
}
