using UnityEngine;
using System.Collections;

public class TrapRun : MonoBehaviour
{
    public float forwardForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeactivateObject(2f));
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forwardForce);
    }

    // 오브젝트를 비활성화하는 Coroutine
    private IEnumerator DeactivateObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}