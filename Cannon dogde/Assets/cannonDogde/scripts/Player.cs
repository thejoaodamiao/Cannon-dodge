using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float dirX = 0f;
    [SerializeField]
    int Lifes = 3;
   

    private UImanager uiManager;
    private GameControl gameControl;
    private Animator anim;
    private Animator anim2;
    private AudioSource dogde;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -1.57f, 0);
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
        anim = GameObject.Find("leftButton").GetComponent<Animator>();
        anim2 = GameObject.Find("rightButton").GetComponent<Animator>();
        dogde = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = CrossPlatformInputManager.GetAxis("Horizontal");

        if (dirX == -1)
        {
            dogde.Play();
            anim.SetBool("leftpressed", true);
        }
      
        else if (dirX == 1)
        {
            dogde.Play();
            anim2.SetBool("rightpressed", true);
        }
        else
        {
            anim2.SetBool("rightpressed", false);
            anim.SetBool("leftpressed", false);
        }

        rb.velocity = new Vector2(dirX * speed, 0);

        if (transform.position.x > 2.0f)
        {
            transform.position = new Vector3(2.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -2.0f)
        {
            transform.position = new Vector3(-2.0f, transform.position.y, 0);
        }
        if(Lifes == 0)
        {
            gameControl.GameOver();
            //Destroy(this.gameObject);
        }
    }
    

    public void Damage()
    {
        Lifes--;
        uiManager.UpdateLives(Lifes);
    } 


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            uiManager.IncreaseYourScore();
            Destroy(other.gameObject);
        }

        if(other.tag == "FireBall")
        {
            Damage();
        }
            
        
    }




}
