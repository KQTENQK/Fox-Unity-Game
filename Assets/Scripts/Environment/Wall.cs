using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _sequenceLength;
    [SerializeField] private int _sequenceCount;
    [SerializeField] private List<GameObject> _rockSequenceTemplates;
    
    private float _xOffset;
    private float _yOffset;

    private void Start()
    {
        _xOffset = GetComponentInParent<PlaneBuilder>().XWallOffset;
        _yOffset = GetComponentInParent<PlaneBuilder>().YWallOffset;

        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < _sequenceCount; i++)
        {
            StartCoroutine(InstantiateSequence(_xOffset, _yOffset, i, _sequenceLength));
            StartCoroutine(InstantiateSequence(-_xOffset, _yOffset, i, _sequenceLength));
        }
    }

    private IEnumerator InstantiateSequence(float offsetX, float offsetY, int iterator, float sequenceLength)
    {
        int randomGenerationIndex = Random.Range(0, _rockSequenceTemplates.Count);
        var rockSequence = Instantiate(_rockSequenceTemplates[randomGenerationIndex], transform);
        rockSequence.transform.localPosition = new Vector3(offsetX, offsetY, iterator * sequenceLength);
        yield return new WaitForFixedUpdate();
    }
}
