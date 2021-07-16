using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    //[SerializeField] private GameObject _planePrefab;
    //[SerializeField] private GameObject _startPlane;

    //private GameObject _currentPlane;

    //private void Start()
    //{
    //    _currentPlane = _startPlane;
    //    _currentPlane.GetComponent<Plane>().PlayerCame += OnPlayerCame;
    //}

    //private void OnPlayerCame()
    //{
    //    _currentPlane.GetComponent<Plane>().PlayerCame -= OnPlayerCame;

    //    Vector3 targetPlanePosition = new Vector3(_currentPlane.transform.position.x,
    //                                            _currentPlane.transform.position.y,
    //                                            _currentPlane.transform.position.z + _currentPlane.GetComponent<Renderer>().bounds.size.z);

    //    var plane = Instantiate(_planePrefab, targetPlanePosition, Quaternion.identity);
    //    _currentPlane = plane;

    //    _currentPlane.GetComponent<Plane>().PlayerCame += OnPlayerCame;
    //}

    //private void OnDisable()
    //{
    //    if (_currentPlane != null)
    //        _currentPlane.GetComponent<Plane>().PlayerCame -= OnPlayerCame;
    //}
}
