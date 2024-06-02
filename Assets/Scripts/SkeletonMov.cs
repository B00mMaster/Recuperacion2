using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMov : MonoBehaviour
{
   public Animator anim;
    
     int action;
     float chrono;
     Quaternion angle;
     float degree;
    float VelRot=0.5f;
    
    bool attack;
    public GameObject player;
    public AudioManager audioManager;
     int skVision;
     float cronoMax;
    int skVisionSelect;
    float attackDist=1f;
     float speed;
     float VelRotToPlayer;

    void Update()
    {
        Enemy();

    }
    public int GetRandomVision()
    {
        skVisionSelect = Random.Range(0, 2);


        if (skVisionSelect == 0)
        {
            skVision = 35;
        }
        else
        {
            skVision = Random.Range(0, 20);
        }
        return skVision;
    }
    void Enemy()
    {
        
        float playerDist = Vector3.Distance(transform.position, player.transform.position);
        if (playerDist>skVision)
        {

            anim.SetBool("run", false);
            chrono += 1 * Time.deltaTime;//adds 1 sec every sec to chrono
            if (chrono >= cronoMax)
            {

                cronoMax = Random.Range(1, 8);
                GetRandomVision();
                action = Random.Range(0, 2);
                chrono = 0;
            }
            switch (action) //alternate in every action sk can do
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    degree = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degree, 0);//rotate in Y
                    action++;
                    break;
                case 2:
                    //rotate and walks forward
                    speed = 1f;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, VelRot);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
             VelRotToPlayer = Random.Range(0.5f, 2f);

            //if its near player, it will attack
            if (playerDist > attackDist && !attack)
            {
                speed = 5f;
                Vector3 lookPos = player.transform.position - transform.position;//show direction from skeleton to player
                
                Quaternion rotation = Quaternion.LookRotation(lookPos);//rotate skeleton to player
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, VelRotToPlayer);
                anim.SetBool("walk", false);

                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);//run to player

                anim.SetBool("attack", false);
            }
            else
            {
                
                anim.SetBool("walk", false);

                anim.SetBool("run",false);

                anim.SetBool("attack", true);
               
               attack = true;
            }
           
        }
    }

    public void Swing()
    {
      
        audioManager.PlaySFX(audioManager.swing);
        anim.SetBool("attack", false);
        attack = false;
    }
    

    

    
}
