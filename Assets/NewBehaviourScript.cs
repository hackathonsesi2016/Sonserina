using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator _animator;
    private int i = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimState()
    {
		print ("clicou");
        i++;
        _animator.SetInteger("Estado", i);
        if (i > 4)
            i = 0;
    }

}
