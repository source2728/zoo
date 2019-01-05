using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class SceneObject : MonoBehaviour
{
    public Animator Animator;

    public void DoMove()
    {
        Animator.SetBool("isMove", true);
    }

    public void DoIdle()
    {
        Animator.SetBool("isMove", false);
    }
}
