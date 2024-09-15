using System;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action Entered;
    public event Action Leaved;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
            Entered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
            Leaved?.Invoke();
    }
}
