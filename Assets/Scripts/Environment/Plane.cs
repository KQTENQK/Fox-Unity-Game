using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    [SerializeField] private GameObject _planeBuilderTemplate;

    public event UnityAction<Plane> PlayerCame;
    public event UnityAction<Plane> Hiding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
            PlayerCame?.Invoke(this);
    }

    public void Hide()
    {
        Hiding?.Invoke(this);
    }
}
