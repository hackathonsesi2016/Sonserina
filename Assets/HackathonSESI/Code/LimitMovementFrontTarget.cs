using UnityEngine;
using System.Collections;
using Vuforia;

public class LimitMovementFrontTarget : MonoBehaviour
{
    private ImageTargetBehaviour _target;

    private void Awake()
    {
        _target = GetComponentInParent<ImageTargetBehaviour>();
    }
}
