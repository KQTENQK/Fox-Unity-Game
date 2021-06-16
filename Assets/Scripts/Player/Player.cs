using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public bool IsAlive { get; private set; }

    public abstract void UseAbility();
}
