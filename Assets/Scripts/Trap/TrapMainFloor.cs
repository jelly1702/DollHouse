using UnityEngine;

public class TrapMainFloor : MonoBehaviour
{
    public GameObject floorObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            floorObject.SetActive(false);
        }
    }
}
