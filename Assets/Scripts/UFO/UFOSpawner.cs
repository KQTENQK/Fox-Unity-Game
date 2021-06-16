using System.Collections;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _zSpawnDistance;
    [SerializeField] private float _maxRandomDistance;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject ufo = transform.GetChild(i).gameObject;
                if (!ufo.activeInHierarchy)
                {
                    ufo.SetActive(true);
                    float xSpawnDistance = ufo.GetComponent<UFOMover>().XEdge - Random.Range(0, _maxRandomDistance);
                    float zSpawnDistance = _zSpawnDistance - Random.Range(0, _maxRandomDistance);
                    ufo.transform.position = new Vector3(_player.transform.position.x + xSpawnDistance,
                                                         ufo.transform.position.y,
                                                         _player.transform.position.z + zSpawnDistance);
                    yield return new WaitForFixedUpdate();
                }
            }

            yield return null;
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Spawn());
    }
}
