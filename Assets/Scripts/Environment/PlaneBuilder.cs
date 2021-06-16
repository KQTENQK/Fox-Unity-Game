using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _wallTemplate;
    [SerializeField] private GameObject _environmentGeneratorTemplate;
    [SerializeField] private float _xWallOffset;
    [SerializeField] private float _yWallOffset;
    [SerializeField] private float _startPosition;
    [SerializeField] private Vector3 _leftLocalTopStartPosition;

    public float XWallOffset => _xWallOffset;
    public float YWallOffset => _yWallOffset;

    private void Awake()
    {
        InstantiateWalls(_wallTemplate);
        InstantiateEnvironmentGenerator(_environmentGeneratorTemplate);
    }

    private void InstantiateWalls(GameObject wallTemplate)
    {
        var walls = Instantiate(wallTemplate, transform);
        walls.transform.localPosition = new Vector3(0, 0, _startPosition);
    }

    private void InstantiateEnvironmentGenerator(GameObject environmentGeneratorTemplate)
    {
        var environmet = Instantiate(environmentGeneratorTemplate, transform);
        environmet.transform.localPosition = new Vector3(_leftLocalTopStartPosition.x, _leftLocalTopStartPosition.y, _leftLocalTopStartPosition.z);
    }
}
