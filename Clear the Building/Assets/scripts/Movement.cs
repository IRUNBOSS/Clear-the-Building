using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform rayStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&OnGroundCheck())
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime, 0f, 15f), 0f);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime,-15f,0f), rb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f,180f,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 179.99f, 0f), turnSpeed* Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime,0f,15f), rb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0.01f, 0f), turnSpeed*Time.deltaTime);


        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }
    private bool OnGroundCheck()
    {
        bool hit = Physics.Raycast(rayStartPoint.position, -rayStartPoint.transform.up, 0.25f);
        Debug.DrawRay(rayStartPoint.position, -rayStartPoint.transform.up * 0.25f, Color.red);
       
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
