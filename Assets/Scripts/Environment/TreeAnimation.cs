using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class TreeAnimation : MonoBehaviour
{
    public void StartDestruction(Transform ufoTransform, float deltaRotationAngle, float pullingSpeed, float randomSpread)
    {
        StartCoroutine(ProcessDestruction(ufoTransform, deltaRotationAngle, pullingSpeed, randomSpread));
    }

    private IEnumerator ProcessDestruction(Transform ufoTransform, float deltaRotationAngle, float pullingSpeed, float randomSpread)
    {
        transform.SetParent(ufoTransform);
        int direction = Random.Range(-1, 1);

        if (direction == 0)
            direction = 1;

        deltaRotationAngle *= direction;

        var spreadValue = Random.Range(0, randomSpread);
        float rotationAngle = deltaRotationAngle - spreadValue;

        while (transform.position.y <= ufoTransform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + pullingSpeed * Time.deltaTime, transform.position.z);
            transform.Rotate(rotationAngle * Time.deltaTime, rotationAngle * Time.deltaTime, rotationAngle * Time.deltaTime);
            
            yield return null;
        }

        Destroy(gameObject);
    }
}
