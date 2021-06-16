using UnityEngine;

public class HeroAnimationHandler : MonoBehaviour
{
    private void Start()
    {
        if (transform.GetChild(0).TryGetComponent<FoxAnimator>(out FoxAnimator foxAnimator))
        {
            foxAnimator.enabled = true;
        }

    }
}
