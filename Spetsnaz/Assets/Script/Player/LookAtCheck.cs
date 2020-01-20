using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCheck : MonoBehaviour
{
  public bool LookAtFlag { get; private set; }
    Animator playerAnimator;
    AnimatorDirector animatorDirector;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        animatorDirector = playerAnimator.GetBehaviour<AnimatorDirector>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (animatorDirector.flag == false)
        //{
        //    LookAtFlag = false;
        //}
        
       // Debug.Log(LookAtFlag);
       // LookAtFlag = false;


      // Debug.Log( ReadTimeFromAnimator(playerAnimator, "makarovAim"));
    }
    void LookAt()
    {
        LookAtFlag = true;
    }
    public void NonLookAt()
    {
        LookAtFlag = false;
        //ここでカメラのローテーションを修正する
        //var armRotation=Camera.main.GetComponent<ArmRotation>();
        //armRotation.ResetRotation()



    }
    private float ReadTimeFromAnimator(Animator animator, string clipname)
    {
        if (animator != null)
        {
            RuntimeAnimatorController ac = animator.runtimeAnimatorController;
            AnimationClip clip = System.Array.Find(ac.animationClips, (AnimationClip) => AnimationClip.name.Equals(clipname));
            if (clip != null)
            {
                return clip.length;
            }
        }
        return 0.0f;
    }
}
