using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerBehaviour : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintMult = 1.33f;
    private float realSprintMult = 1f;

    public Vector2 movement = Vector2.zero;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetButton("Sprint"))
        {
            realSprintMult = sprintMult;
        }
        else
        {
            realSprintMult = 1f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movement.x, 0f, movement.y) * moveSpeed * realSprintMult * 10f * Time.deltaTime;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward * 3f);
    }
}
