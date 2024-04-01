using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    private Transform playerTransfer;
    private Rigidbody playerRB;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerTransfer = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransfer.Translate(Input.GetAxis("Horizontal") * speed * Vector3.right * Time.deltaTime);
        playerTransfer.Translate(Input.GetAxis("Vertical") * speed * Vector3.forward * Time.deltaTime);

        // playerRB.AddForce(playerTransform.forward * Input.GetAxis("Vertical") * speed); //accelerate

        playerTransfer.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        Debug.Log(Input.GetAxis("Horizontal"));

        if (isGrounded && Input.GetAxis("Jump") == 1)
        {
            playerRB.velocity = Input.GetAxis("Jump") * playerRB.velocity + Vector3.up * jumpSpeed;
            isGrounded = false;
            Debug.Log(isGrounded);
        }

        
    }
}
