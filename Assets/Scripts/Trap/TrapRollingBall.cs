using UnityEngine;
using System.Collections;

public class TrapRollingBall : TrapController
{
    public float forwardForce = 10f;
    public float torqueForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeactivateObject(6f));
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forwardForce);
        rb.AddTorque(transform.right * torqueForce);
    }
    private IEnumerator DeactivateObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}