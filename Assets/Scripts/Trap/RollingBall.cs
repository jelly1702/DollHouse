using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float forwardForce = 10f;
    public float torqueForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옵니다
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 공을 앞으로 이동시키기 위해 힘을 추가합니다
        rb.AddForce(transform.forward * forwardForce);

        // 공이 앞으로 굴러가도록 회전력을 추가합니다
        rb.AddTorque(transform.right * torqueForce);
    }
}