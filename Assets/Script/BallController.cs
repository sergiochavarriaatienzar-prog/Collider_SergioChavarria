using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float fuerzaTiro = 500f;
    private Rigidbody rb;
    private Vector3 startPosition;
    public float velRotacion = 100f;
    public float rayoDistancia = 10f;
    private LineRenderer line;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * velRotacion * Time.deltaTime, 0);

        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * rayoDistancia;

        line.SetPosition(0, start);
        line.SetPosition(1, end);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * fuerzaTiro);

            line.enabled = false;
        }

        if (transform.position.y < -5)
        {
            ResetPos();
        }
    }

    void ResetPos()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
