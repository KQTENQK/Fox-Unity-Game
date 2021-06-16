using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _xPlaceAreaBounds;
    [SerializeField] private float _step;
    [SerializeField] private float _height;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private GameObject _sphereTemplate;
    [SerializeField] private float _spawnTimeOut;

    private int _zSize;

    private void Awake()
    {
        Renderer planeRenderer = GetComponentInParent<Plane>().gameObject.GetComponent<Renderer>();
        _zSize = (int)planeRenderer.bounds.size.z;
    }

    private void Start()
    {
        StartCoroutine(BeginPlacingSpheres());
    }

    private void OnDestroy()
    {
        StopCoroutine(BeginPlacingSpheres());
    }

    private IEnumerator BeginPlacingSpheres()
    {
        while(true)
        {
            PlaceSphere();
            yield return new WaitForSeconds(_spawnTimeOut);
        }
    }

    private void PlaceSphere()
    {
        var spawnPosition = SelectPlace();
        var sphere = Instantiate(_sphereTemplate, transform);
        sphere.transform.localPosition = spawnPosition;
    }

    private Vector3 SelectPlace()
    {
        int randomPlaceX = Random.Range(0, 5);

        return new Vector3(_xPlaceAreaBounds.x - (_step * randomPlaceX), _height, _zSize - Random.Range(0, _zSize - _spawnDistance));
    }
}
