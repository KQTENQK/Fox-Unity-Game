using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] private float _deltaRotationAngle;
    [SerializeField] private float _pullingSpeed;
    [SerializeField] protected int _price;
    [SerializeField] protected string _label;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected bool _isBuyed;
    [SerializeField] protected string _name;

    public int Price => _price;
    public string Label => _label;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public string Name => _name;

    public event Action SpherePickedUp;
    public event Action Died;

    abstract protected void Ultimate();

    public void Buy()
    {
        _isBuyed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Sphere>(out Sphere sphere))
            SpherePickedUp?.Invoke();

        if (other.TryGetComponent<UFO>(out UFO ufo))
        {
            Die(ufo.transform, _deltaRotationAngle, _pullingSpeed);
            Died?.Invoke();
        }
    }

    private void Die(Transform ufoTransform, float deltaRotationAngle, float pullingSpeed)
    {
        StartCoroutine(ProcessDestruction(ufoTransform, deltaRotationAngle, pullingSpeed));
    }

    private IEnumerator ProcessDestruction(Transform ufoTransform, float deltaRotationAngle, float pullingSpeed)
    {
        transform.SetParent(ufoTransform);
        int direction = UnityEngine.Random.Range(-1, 1);

        if (direction == 0)
            direction = 1;

        deltaRotationAngle *= direction;

        while (transform.position.y <= ufoTransform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + pullingSpeed * Time.deltaTime, transform.position.z);
            transform.Rotate(deltaRotationAngle * Time.deltaTime, deltaRotationAngle * Time.deltaTime, deltaRotationAngle * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}
