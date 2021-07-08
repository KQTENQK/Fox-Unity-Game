using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float _deltaRotationAngle;
    [SerializeField] private float _pullingSpeed;
    [SerializeField] private float _randomSpread;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<TreeAnimation>(out TreeAnimation treeAnimation))
        {
            treeAnimation.StartDestruction(transform, _deltaRotationAngle, _pullingSpeed, _randomSpread);
        }

        if (other.gameObject.TryGetComponent<Hero>(out Hero hero))
        {
            Debug.Log("dead");
        }
    }
}
