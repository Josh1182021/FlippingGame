using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnimator : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);//could replace 0 by any other animation layer index
        animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
