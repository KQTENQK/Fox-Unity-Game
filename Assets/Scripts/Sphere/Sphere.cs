using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void PickingSphere(Hero hero)
    {
        hero.GetComponentInParent<Player>().CollectSphere();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
        {
            PickingSphere(hero);
        }
    }
}
