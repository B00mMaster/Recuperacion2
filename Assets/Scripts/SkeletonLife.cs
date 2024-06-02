using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonLife : MonoBehaviour
{
    public GameObject[] skeleton;
    public ParticleSystem blood1, blood2, blood3;
    int skLife = 2;
    public Animator anim;
    public AudioManager audioManager;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("AssaultRifle"))
        {
            skLife--;
            audioManager.PlaySFX(audioManager.skScream);
           anim.SetBool("attack", false);
            anim.SetBool("damage", true);
            
            if (skLife == 0)
            {
                anim.SetBool("damage", true);
                anim.SetBool("death", true);
            }
        }

    }
   
    public void DamageEnd()
    {
        anim.SetBool("damage", false);
    }

    public void OnDestroy()
    {
        //destroy skeleton
        Destroy(gameObject);
    }

    public void Particle()
    {
        blood1.Play();
        blood2.Play();
        blood3.Play();
    }


}
