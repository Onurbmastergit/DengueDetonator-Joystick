using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public GameObject handAerosol;
    public GameObject handAerosol2;
    public GameObject handSand;
    public GameObject handSand2;
    public GameObject handRaquete;
    public GameObject handRaquete1;
    public GameObject barSandLimt;
    public GameObject barsSand1;
    public GameObject barsSand2;
    public GameObject barsSand3;
    public GameObject barsSand4;
    public GameObject barsSand5;
    public GameObject barSprayLimit;
    public GameObject barSpray1;
    public GameObject barSpray2;
    public GameObject barSpray3;
    public GameObject barSpray4;
    public GameObject IconRaquete;
    public GameObject IconSpray;
    public GameObject IconSand;

    public AudioSource Spray;
    public AudioSource Raquetada;
    

    public Animator handAnimator;
    

    public  int sprayLimit = 4;
    
    public  int sandLimit = 5;
    public int numHands;
    public bool enabledHand = true;
    public bool EndAnimation = true;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        numHands = 1;
        handAerosol.SetActive(enabledHand);
        handAerosol2.SetActive(!enabledHand);
        EndAnimation = true;
    }

    void Update()
    {
        if(sprayLimit == 4)
        {
        barSpray4.SetActive(true);
        barSpray3.SetActive(true);
        barSpray2.SetActive(true);
        barSpray1.SetActive(true);
        }
         if(sprayLimit == 3)
        {
        barSpray4.SetActive(false);
        barSpray3.SetActive(true);
        barSpray2.SetActive(true);
        barSpray1.SetActive(true);
        }
         if(sprayLimit == 2)
        {
        barSpray4.SetActive(false);
        barSpray3.SetActive(false);
        barSpray2.SetActive(true);
        barSpray1.SetActive(true);
        }
         if(sprayLimit == 1)
        {
        barSpray4.SetActive(false);
        barSpray3.SetActive(false);
        barSpray2.SetActive(false);
        barSpray1.SetActive(true);
        }
         if(sprayLimit == 0)
        {
        barSpray4.SetActive(false);
        barSpray3.SetActive(false);
        barSpray2.SetActive(false);
        barSpray1.SetActive(false);
        }
        
         if(sandLimit == 5)
        {
        barsSand5.SetActive(true);
        barsSand4.SetActive(true);
        barsSand3.SetActive(true);
        barsSand2.SetActive(true);
        barsSand1.SetActive(true);
        }
        if(sandLimit == 4)
        {
        barsSand5.SetActive(false);    
        barsSand4.SetActive(true);
        barsSand3.SetActive(true);
        barsSand2.SetActive(true);
        barsSand1.SetActive(true);
        }
         if(sandLimit == 3)
        {
        barsSand5.SetActive(false);    
        barsSand4.SetActive(false);
        barsSand3.SetActive(true);
        barsSand2.SetActive(true);
        barsSand1.SetActive(true);
        }
         if(sandLimit == 2)
        {
        barsSand5.SetActive(false);    
        barsSand4.SetActive(false);
        barsSand3.SetActive(false);
        barsSand2.SetActive(true);
        barsSand1.SetActive(true);
        }
         if(sandLimit == 1)
        {
        barsSand5.SetActive(false);    
        barsSand4.SetActive(false);
        barsSand3.SetActive(false);
        barsSand2.SetActive(false);
        barsSand1.SetActive(true);
        }
         if(sandLimit == 0)
         {
        barsSand5.SetActive(false);    
        barsSand4.SetActive(false);
        barsSand3.SetActive(false);
        barsSand2.SetActive(false);
        barsSand1.SetActive(false);
         }

        
        
        if (numHands == 1 && sprayLimit >= 0)
        {
            handAnimator.SetBool("Aerosol" , true);
            handAnimator.SetBool("Raquete", false);
            handAnimator.SetBool("Sand", false);
            handSand.SetActive(false);
            handSand2.SetActive(false);
            handRaquete.SetActive(false);
            handRaquete1.SetActive(false);
            barSprayLimit.SetActive(true);
            barSandLimt.SetActive(false);
            IconSpray.SetActive(true);
            IconSand.SetActive(false);
            IconRaquete.SetActive(false);
            handAerosol.SetActive(enabledHand);
            handAerosol2.SetActive(!enabledHand);
            if (enabledHand == false)
            {
                Invoke("EnalbedHand", 0.3f);
            }
        }
        if (numHands == 2 && sandLimit >= 0)
        {
            handAnimator.SetBool("Aerosol", false);
            handAnimator.SetBool("Raquete", false);
            handAnimator.SetBool("Sand", true);
            handAerosol.SetActive(false);
            handAerosol2.SetActive(false);
            handRaquete.SetActive(false);
            handRaquete1.SetActive(false);
             barSprayLimit.SetActive(false);
            barSandLimt.SetActive(true);
            IconSpray.SetActive(false);
            IconSand.SetActive(true);
            IconRaquete.SetActive(false);
            handSand.SetActive(enabledHand);
            handSand2.SetActive(!enabledHand);
            if (enabledHand == false)
            {
                Invoke("EnalbedHand", 0.3f);
            }
        }
        if(numHands == 3)
        {
            handAnimator.SetBool("Aerosol", false);
            handAnimator.SetBool("Sand", false);
            handAnimator.SetBool("Raquete", true);
            handAerosol.SetActive(false);
            handAerosol2.SetActive(false);
            handSand.SetActive(false);
            handSand2.SetActive(false);
             barSprayLimit.SetActive(false);
            barSandLimt.SetActive(false);
            IconSpray.SetActive(false);
            IconSand.SetActive(false);
            IconRaquete.SetActive(true);
            handRaquete.SetActive(enabledHand);
            handRaquete1.SetActive(!enabledHand);
            if (enabledHand == false)
            {
                Invoke("EnalbedHand", 0.3f);
            }
        }
        if(numHands > 3 || numHands < 1)
        {
            numHands = 1;
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button4) )
        {
            numHands--;
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            numHands++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            numHands = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            numHands = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            numHands = 3;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)|| Input.GetButtonDown("Fire1") ) 
        {
           
            HandAnimation();
        }

        if (numHands == 1 && sprayLimit < 0) 
        {
            numHands = 3;
        }
        if (numHands == 2 && sandLimit < 0) 
        {
            numHands = 3;
        }
       

    }

    void HandAnimation() 
    {
        enabledHand = !enabledHand;
        if (numHands == 1 && sprayLimit >= 0)
        {
            Spray.Play();
            handAerosol.SetActive(enabledHand);
            handAerosol2.SetActive(!enabledHand);
            
            if (enabledHand != true && numHands == 1 && sprayLimit >= 0)
            {
                Debug.Log($"Resta apenas{sprayLimit}");
                sprayLimit--;
            }
        }
        if (numHands == 2 && sprayLimit >= 0)
        {   
            handSand.SetActive(enabledHand);
            handSand2.SetActive(!enabledHand);
           
            if (enabledHand != true && numHands == 2 && sandLimit >= 0)
            {
                Debug.Log($"Resta apenas{sandLimit}");
                sandLimit--;
            }
        }
        if(numHands == 3)
        {
            Raquetada.Play();
           handRaquete.SetActive(enabledHand);
           handRaquete1.SetActive(!enabledHand);
           
          
        }
       
    }
    void EnalbedHand() 
    {
        enabledHand = true;
    }
   
}
