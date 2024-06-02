using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
   
    public Animator anim;
    public ParticleSystem shoot, shoot1, shoot2, shoot3,shoot4;
    int bullets = 4;
    public Image[] bulletImage;
    public AudioManager audioManager;
    
    public void UpdateUI()
    {
        //se mostraran tantas balas como haya en el array
        for(int i=0;i<bulletImage.Length;i++)
        {
            if(i<bullets)
            {
                bulletImage[i].enabled = true;
            }
            else
            {
                
                bulletImage[i].enabled = false;
            }
        }
    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            bullets--;//se gasta 1 bala al disparar con el raton
            anim.SetBool("Shoot", true);
            audioManager.PlaySFX(audioManager. shoot);
            UpdateUI();//actualizar las balas en UI
            StartCoroutine(Shoot());
            if(bullets == 0)
            {
                audioManager.PlaySFX(audioManager.reload);
                anim.SetBool("reload", true);
                bullets=4;
                UpdateUI();

            }


        }
        else
        {
            anim.SetBool("Shoot", false);

        }
        IEnumerator Shoot()
        {
            shoot.Play();
            shoot1.Play();
            shoot2.Play();
            shoot3.Play();
            shoot4.Play();
            yield return new WaitForSeconds(0.2f);
            //wait for desappear particles
            shoot.Stop();
            shoot1.Stop();
            shoot2.Stop();
            shoot3.Stop();
            shoot4.Stop();
            
        }
        if(Input.GetKeyDown(KeyCode.R)&&bullets<4)
        {
            audioManager.PlaySFX(audioManager.reload);

            anim.SetBool("reload", true);
            bullets=4;
            
        }
        
    }

    public void FinishReload()
    {
        anim.SetBool("reload", false);
       
    }
}
