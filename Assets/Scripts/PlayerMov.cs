using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMov : MonoBehaviour
{
    public GameObject player;
    float speed=1.5f;
    float rotSpeed = 2f;
    float horizontalInput, verticalInput;
    public Animator anim;
    

    public Image staminaBar;
    float stamina;
    float staminaMax=100;
     float recover=10;
    float consume=30;
    
   
    private void Start()
    {
        stamina = staminaMax;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    int state = 0;
    void Update()
    {
      
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        float rotationInput = Input.GetAxis("Mouse X")*rotSpeed;

        Vector3 mov = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        transform.Translate(mov, Space.Self);

        player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + rotationInput, 0);
        

        anim.SetFloat("X", horizontalInput);
        anim.SetFloat("Y", verticalInput);

        
        

        if (verticalInput > 0f && Input.GetKey(KeyCode.Q))
        {
            state = 1;
            speed = 8f;
            StaminaConsume();
           
        }
        if (verticalInput < 0f && Input.GetKey(KeyCode.Q))
        {
            state = 2;
            speed = 8f;
            StaminaConsume();
            
        }
        if(!Input.GetKey(KeyCode.Q))
        {
            Slow();
        }
        if (horizontalInput>0|| horizontalInput<0 && Input.GetKey(KeyCode.Q) && stamina <=0)
        {

            Slow();
        }
        anim.SetInteger("state", state);
        StaminaRecover();

        staminaBar.fillAmount=stamina/staminaMax;

    }
   
    void Slow()
    {
        speed = 1.5f;
        state = 0;
        
    }
  void StaminaConsume()
  {
        stamina-=consume*Time.deltaTime;

        if(stamina<=0)
        {
            stamina=0;
            speed = 1.5f;
            state = 0;
        }
  }

    void StaminaRecover()
    {
        stamina += recover * Time.deltaTime;

        if(stamina>staminaMax)
        {
            stamina = staminaMax;
        }
    }
}
