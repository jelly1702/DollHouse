using UnityEngine;
using System.Collections;

public class ManController : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardForce = 10f;
    public bool isMoving = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeactivateObject(2f));
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(transform.forward * forwardForce);
        }
    }

    private IEnumerator DeactivateObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}