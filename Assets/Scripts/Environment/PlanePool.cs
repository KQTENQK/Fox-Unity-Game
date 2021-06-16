using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePool : MonoBehaviour
{
    [SerializeField] private int _activePlanesInOneMoment;
    [SerializeField] private List<GameObject> _inactivePlanes;

    private List<GameObject> _settledPlanes;
    private Vector3 _currentSettleBounds = Vector3.zero;

    private void Awake()
    {
        _settledPlanes = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 1; i < _activePlanesInOneMoment; i++)
        {
            PlacePlane();
        }
    }

    private void PlacePlane()
    {
        int randomIndex = Random.Range(0, _inactivePlanes.Count);
        var plane = _inactivePlanes[randomIndex];
        plane.SetActive(true);
        _inactivePlanes.RemoveAt(randomIndex);
        plane.transform.position = _currentSettleBounds;
        plane.GetComponent<Plane>().PlayerCame += OnPlayerCame;
        plane.GetComponent<Plane>().Hiding += OnHiding;
        _settledPlanes.Add(plane);

        Renderer planeRenderer = plane.GetComponent<Renderer>();
        _currentSettleBounds = new Vector3(plane.transform.position.x,
                                                    plane.transform.position.y,
                                                    plane.transform.position.z + planeRenderer.bounds.size.z);
    }

    private void OnPlayerCame(Plane plane)
    {
        PlacePlane();
        plane.PlayerCame -= OnPlayerCame;
    }

    private void OnHiding(Plane plane)
    {
        _settledPlanes.Remove(plane.gameObject);
        _inactivePlanes.Add(plane.gameObject);

        plane.Hiding -= OnHiding;
        plane.gameObject.SetActive(false);
    }
}
