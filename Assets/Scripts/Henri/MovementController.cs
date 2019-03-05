using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool rotateToMainCamera = false;
    public bool rotateWeapon = false;
    public float moveSpeed = 10f;
    public float jumpheight = 10f;
    public Rigidbody rigid;
    public float RayDistance = 1f;

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);

        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * RayDistance);
    }

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        Vector3 camEuler = Camera.main.transform.eulerAngles;
        if (rotateToMainCamera)
        {
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }

        Quaternion PlayerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);

   
    }
}
