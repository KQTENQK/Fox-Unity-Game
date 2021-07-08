using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Plane>(out Plane plane))
            Destroy(plane.gameObject);

        if (other.TryGetComponent<UFO>(out UFO ufo))
            ufo.gameObject.SetActive(false);
    }
}
