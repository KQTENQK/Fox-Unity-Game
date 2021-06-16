using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDeadzoneRemover : MonoBehaviour
{
    [SerializeField] private GameObject _firstPlane;
    
    private GameObject _currentPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Plane>(out Plane plane))
        {
            StartCoroutine(DestroyPlane(_currentPlane));
            _currentPlane = plane.gameObject;
        }
    }

    private void Start()
    {
        _currentPlane = _firstPlane;
    }

    private IEnumerator DestroyPlane(GameObject currentPlane)
    {
        Destroy(currentPlane);
        yield return new WaitForEndOfFrame();
    }
}
