using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    CharacterController rb;
    [SerializeField] GameObject player;
    [SerializeField]float speed = 5;
    float gravity = 9.81f;
    float jump_height = 2f;
    float verticalvelocity;
    public float horizontalMultiplier = 2;
    [SerializeField] LayerMask groundmask;
    Animator animator;
    [SerializeField]private Vector3 moveVector;
    public AudioClip[] FootstepAudioClips; 
    public AudioClip jumpclip;
    public AudioClip dieclip;
    [SerializeField]bool isalive; 
   
    
    private void Start()
    {
        Cursor.visible = false;

        isalive = true;
        rb = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
       
    }
   
    private float VerticalforceCla()
    {
        if (rb.isGrounded)
        {
            verticalvelocity = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("jump");
                verticalvelocity = Mathf.Sqrt(jump_height * gravity * 2);
            }
        }
        else
        {
            verticalvelocity -= gravity * Time.deltaTime;
        }
        return verticalvelocity;
    }

    private void FixedUpdate()
    {

        if (!isalive)
            return;

        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalMultiplier;
        moveVector.y = VerticalforceCla();
        moveVector.z = speed;
        rb.Move(moveVector * Time.deltaTime);

        
    }


    public void die()
    {
        isalive = false;
        Cursor.visible = true;
        game_manager.instance.die();
        AudioSource.PlayClipAtPoint(dieclip, transform.TransformPoint(rb.center), 1f);
        player.SetActive (false);
    }
    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(rb.center), 0.8f);
            }
        }
        }

    }
