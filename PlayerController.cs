using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  private Rigidbody rb;
  public float gravityMod;
  public float jumpForce ;
  public bool isOnGround=true;
  public bool gameHasEnded =false;
  private Animator playerAnim;
  public ParticleSystem ep;
  public ParticleSystem dp;
  public AudioClip jumpSound;
  public AudioClip crashSound;
  public AudioSource playerAudio;
  public bool doubleJumpUsed = false;
  public float doubleJumpForce ;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMod;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameHasEnded && !doubleJumpUsed )
        {
            isOnGround= false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dp.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound,1.0f);
            doubleJumpUsed = true;
        }else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround&& !doubleJumpUsed && !gameHasEnded)
            {
               
                rb.AddForce(Vector3.up * doubleJumpForce,ForceMode.Impulse);
                playerAnim.Play("Running_Jump", 3);
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                doubleJumpUsed = false;

            }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
       {
            isOnGround=true;
            dp.Play();
        }
      else if (collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game Over !!!");
            gameHasEnded=true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            ep.Play();
            dp.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
            
    }

}