using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInitializer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _avatarTemplates;
    [SerializeField] private int _selectedAvatarIndex;

    private void Start()
    {
        Instantiate(_avatarTemplates[_selectedAvatarIndex], transform);
    }
}
