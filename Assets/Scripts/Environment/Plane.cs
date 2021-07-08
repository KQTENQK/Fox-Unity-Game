using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    [SerializeField] private GameObject _planeBuilderTemplate;

    public event UnityAction PlayerCame;

    private void Start()
    {
        Instantiate(_planeBuilderTemplate, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
        {
            PlayerCame?.Invoke();
        }
    }
}
