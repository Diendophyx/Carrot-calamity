using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int jumpHeight = 10;
    public bool isGrounded;
    public float rayDistance = 1f;

    // Use this for initialization
    void FixedUpdate()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
        }

    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);
    }

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);

        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance)) // cast a line beneath th player
        {
            return true; // is grounded so return true
        }
        return false; // is not grounded so return false
    }

}
