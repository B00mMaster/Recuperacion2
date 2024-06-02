using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
     float life = 1f;
     float lifeMax = 1f;
     float damage = 0.25f;
    public Animator anim,PostPro;
    public AudioManager audioManager;
    public Image lifeBar;

    private void Update()
    {
        //the status of the life bar willbe displayed
        lifeBar.fillAmount=life/lifeMax;
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("sword"))//player lost life colliding with sword
        {
            life=life-damage;
            audioManager.PlaySFX(audioManager.playerScream[Random.Range(0,audioManager.playerScream.Length)]);
            anim.SetBool("reload", false);
            anim.SetBool("damage", true);
            PostPro.SetBool("PostProDamage", true);
           
        }
        if (player.CompareTag("plant")&&life<1)//gain life colliding whit plant
        {
            life=life+damage;

        }
        if(life<=0)//when life is 0, go to game over scene
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    

    public void StopDamage() //exit form the animation
    {
        anim.SetBool("damage", false);
        PostPro.SetBool("PostProDamage", false);
    }
}
