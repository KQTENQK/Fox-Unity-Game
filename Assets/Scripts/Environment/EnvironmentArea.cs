using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentArea : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;

    public Vector2Int Size => _size;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < _size.x; x++)
        {
            for (int z = 0; z < _size.y; z++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, z), new Vector3(1, .1f, 1));
            }
        }
    }
}
