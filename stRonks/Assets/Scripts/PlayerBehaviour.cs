using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerBehaviour : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotSpeed = 40f;
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
        Quaternion _rot;

        if (movement.y < 0)
        {
            _rot = Quaternion.Euler(new Vector3(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y + (-movement.x * rotSpeed * 100f * Time.deltaTime), gameObject.transform.rotation.eulerAngles.z));
        }
        else
        {
            _rot = Quaternion.Euler(new Vector3(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y + (movement.x * rotSpeed * 100f * Time.deltaTime), gameObject.transform.rotation.eulerAngles.z));
        }
        gameObject.transform.rotation = _rot;

        rb.MovePosition(gameObject.transform.position + (gameObject.transform.forward * movement.y * moveSpeed * realSprintMult * Time.deltaTime));
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward * 3f);
    }
}
