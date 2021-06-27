using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f;

    Rigidbody rigidbody;
    Vector3 velocity;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovemnt = Input.GetAxis("Vertical");
        velocity = new Vector3(horizontalMovement, 0, verticalMovemnt);
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (velocity * movementSpeed * Time.deltaTime));
    }
}
