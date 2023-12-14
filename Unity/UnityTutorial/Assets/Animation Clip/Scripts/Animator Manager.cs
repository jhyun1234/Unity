using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[] animationClip; 


    void Start()
    {
        for(int i=0; i<animationClip.Length; i++)
        {
            var data = AnimationUtility.GetAnimationClipSettings(animationClip[i]);
            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClip[i], data);
        }

    }

    
    void Update()
    {
        // GetCurrentAnimatorStateInfo(0).IsName("Close")
        // 현재 애니메이션의 이름이 "Close" 라면
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            // animator.GetCurrentAnimatorStateInfo(0).normalizedTime
            // 현재 진행한 애니메이션의 실행 상태를 의미한다.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >=1)
            {
                // SetActive : 게임 오브젝트를 활성화 또는 비활성화 할 수 있는 함수이다.
                animator.gameObject.SetActive(false);
            }
        }
           
          

    }
}
