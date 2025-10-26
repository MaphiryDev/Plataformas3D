using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movSpeed;
    private Rigidbody rbPlayer;
    public bool isGrounded = true;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject[] vida;
    private int vidaPlayer;

    [SerializeField] private SpriteRenderer playeSprite;

    [SerializeField] private Animator animator;

    [SerializeField] private CanvasGameOverController cC;

    private float horizontalAxis = 0f;
    private float verticalAxis = 0f;

    private float horizontalRotation;

    private bool isWalking = false;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = this.gameObject.GetComponent<Rigidbody>();
        vidaPlayer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        Jump();
        Animations();
    }

    private void FixedUpdate()
    {
        PlayerRotation();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 moveDirectionVertical = transform.forward * movSpeed * Time.fixedDeltaTime * verticalAxis;
        rbPlayer.MovePosition(rbPlayer.position + moveDirectionVertical);
        // Movimiento hacia adelante
        if (verticalAxis == 0) 
        { 
            
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }
    }

    private void PlayerRotation()
    {
        horizontalRotation = horizontalAxis * rotationSpeed * Time.fixedDeltaTime;
        rbPlayer.MoveRotation(Quaternion.Euler(0, rbPlayer.rotation.eulerAngles.y + horizontalRotation, 0));


    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    public void PerderVida()
    {
        vidaPlayer--;
        
        if (vidaPlayer == 2)
            vida[2].SetActive(false);
        else if (vidaPlayer == 1)
            vida[1].SetActive(false);
        else if (vidaPlayer == 0)
        {
            vida[0].SetActive(false);
            cC.GameOver();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Tocando suelo..."+collision.gameObject.name);
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Animations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }
}
