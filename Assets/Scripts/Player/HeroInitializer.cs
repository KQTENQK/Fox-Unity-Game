using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class HeroInitializer : MonoBehaviour
{
    [SerializeField] private List<Hero> _avatarTemplates;
    [SerializeField] private Data gameData;

    private Hero _hero;

    private void Awake()
    {
        foreach (var hero in _avatarTemplates)
        {
            if (gameData.ctx.SelectedHero == hero.Name)
                _hero = hero;
        }
    }

    private void Start()
    {
        var player = Instantiate(_hero, transform);
        player.GetComponent<Animator>().SetTrigger("ExitStartScreen");
    }
}
