using System;
using UnityEngine;

public class ExitSquarePoint : MonoBehaviour
{
    [SerializeField] private float radius = 2.5f;
    public static Action OnPlayerEnterOnExitPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnPlayerEnterOnExitPoint?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
