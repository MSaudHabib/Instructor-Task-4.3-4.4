using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    public float horizontalInput;
    public float forwardInput;
    private Vector3 movement;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public bool gameOver;
    public GameObject bombPrefab;
    public GameObject bombThrowPosition;
    public float throwforce;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Taking player forward and horizontal inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalInput, 0, forwardInput);

        // Throwing bomb
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bombPrefab = Instantiate(bombPrefab, bombThrowPosition.transform.position, bombThrowPosition.transform.rotation);
            bombPrefab.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwforce);
        }
    }

    private void FixedUpdate()
    {
        // If game is not over player can move
        if (!gameOver)
        {
            playerRb.AddForce(movement * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.LookRotation(movement);
            playerAnim.SetFloat("Speed_f", 0.3f);
        }

        // If player press left shift button then player will sprint otherwise player will walk
        if (Input.GetKey(KeyCode.LeftShift) && !gameOver)
        {
            speed = 7.5f;
            playerRb.AddForce(movement * speed, ForceMode.Impulse);
            transform.rotation = Quaternion.LookRotation(movement);
            playerAnim.SetFloat("Speed_f", 0.6f);
        }
        else
        {
            speed = 5;
            playerAnim.SetFloat("Speed_f", 0.3f);
        }

        // If player is still (no movement) no animation will pe played
        if (forwardInput == 0 && horizontalInput == 0)
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
    }
}
