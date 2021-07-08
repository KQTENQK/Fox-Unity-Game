using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAreaGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _placeAreaBounds;
    [SerializeField] private int _xWallIndent;
    [SerializeField] private int _rarity;
    [SerializeField] private List<GameObject> _environmentOutGameAreaTemplates;
    [SerializeField] private List<GameObject> _environmentInGameAreaTemplates;

    private Vector2Int _size;
    private float _xLeftWallOffset;
    private float _xWallLength;
    private GameObject[,] _grid;

    private void Awake()
    {
        Renderer planeRenderer = GetComponentInParent<Plane>().gameObject.GetComponent<Renderer>();
        _size = new Vector2Int((int)planeRenderer.bounds.size.x, (int)planeRenderer.bounds.size.z);
        _grid = new GameObject[_size.x - _placeAreaBounds.x, _size.y - _placeAreaBounds.y];
        _xLeftWallOffset = (_size.x / 2) - GetComponentInParent<PlaneBuilder>().XWallOffset - _xWallIndent;
        _xWallLength = 2 * GetComponentInParent<PlaneBuilder>().XWallOffset + _xWallIndent;
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private void TryPlaceEnvironmentArea(GameObject template, int x, int z, int rarity = 0)
    {
        int toBeSet = Random.Range(0, rarity);
        var areaSize = template.GetComponent<EnvironmentArea>().Size;

        if (x + areaSize.x > _grid.GetLength(0) || z + areaSize.y > _grid.GetLength(1))
            return;

        if (toBeSet == 0)
        {
            var area = Instantiate(template, transform);
            area.transform.localPosition = new Vector3(x, 0, z);

            for (int ix = 0; ix < areaSize.x; ix++)
            {
                for (int iz = 0; iz < areaSize.y; iz++)
                {
                    _grid[x + ix, z + iz] = area;
                }
            }
        }
    }

    private IEnumerator Generate()
    {
        for (int z = 0; z < _grid.GetLength(1); z++)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if (_grid[x, z] == null)
                {
                    GameObject selectedArea;
                    if (x >= (int)(_xLeftWallOffset) && x < (int)(_xLeftWallOffset + _xWallLength))
                    {
                        selectedArea = _environmentInGameAreaTemplates[Random.Range(0, _environmentInGameAreaTemplates.Count)];
                        TryPlaceEnvironmentArea(selectedArea, x + _xWallIndent, z, _rarity);
                    }
                    else
                    {
                        selectedArea = _environmentOutGameAreaTemplates[Random.Range(0, _environmentOutGameAreaTemplates.Count)];
                        TryPlaceEnvironmentArea(selectedArea, x, z, _rarity);
                    }
                }
            }
            yield return null;
        }
    }
}
