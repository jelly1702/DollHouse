using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float forwardForce = 10f;
    public float torqueForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        // Rigidbody ������Ʈ�� �����ɴϴ�
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ���� ������ �̵���Ű�� ���� ���� �߰��մϴ�
        rb.AddForce(transform.forward * forwardForce);

        // ���� ������ ���������� ȸ������ �߰��մϴ�
        rb.AddTorque(transform.right * torqueForce);
    }
}