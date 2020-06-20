using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;
    void Start()
    {
        forward = Camera.main.transform.forward; //forward vector equals cameras vector tussen main en forward is transform
        forward.y = 0;
        forward = Vector3.Normalize(forward); //keeps the vectors direction, but making sure the lengths are 1 or 0
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // creating a rotation for our right vector, 0, 90,0
        
    }

  
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading; //makes rotation happen
        transform.position += rightMovement; //makes movement happen
        transform.position += upMovement; //makes movement happen

    }
}
