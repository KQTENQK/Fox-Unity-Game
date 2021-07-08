using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _wallTemplate;
    [SerializeField] private GameObject _environmentGeneratorTemplate;
    [SerializeField] private GameObject _sphereSpawnerTemplate;
    [SerializeField] private float _xWallOffset;
    [SerializeField] private float _yWallOffset;

    private Vector3 _wallStartPlacingPosition;
    private Vector3 _leftLocalTopStartPosition;
    private Vector3 _sphereStartPlacingPosition;

    public float XWallOffset => _xWallOffset;
    public float YWallOffset => _yWallOffset;

    private void Awake()
    {
        Renderer planeRenderer = GetComponentInParent<Plane>().gameObject.GetComponent<Renderer>();
        _leftLocalTopStartPosition = new Vector3(planeRenderer.bounds.min.x, 0, planeRenderer.bounds.min.z);
        _wallStartPlacingPosition = new Vector3(0, 0, planeRenderer.bounds.min.z);
        _sphereStartPlacingPosition = _wallStartPlacingPosition;
        InstantiateWalls(_wallTemplate);
        InstantiateEnvironmentGenerator(_environmentGeneratorTemplate);
        InstantiateSphereSpawner(_sphereSpawnerTemplate);
    }

    private void InstantiateWalls(GameObject wallTemplate)
    {
        var walls = Instantiate(wallTemplate, transform);
        walls.transform.position = _wallStartPlacingPosition;
    }

    private void InstantiateEnvironmentGenerator(GameObject environmentGeneratorTemplate)
    {
        var environmet = Instantiate(environmentGeneratorTemplate, transform);
        environmet.transform.position = _leftLocalTopStartPosition;
    }

    private void InstantiateSphereSpawner(GameObject sphereSpawnerTemplate)
    {
        var sphereGenerator = Instantiate(sphereSpawnerTemplate, transform);
        sphereGenerator.transform.position = _sphereStartPlacingPosition;
    }
}
