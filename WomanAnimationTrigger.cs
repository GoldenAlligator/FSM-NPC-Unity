using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanAnimationTrigger : MonoBehaviour
{
    NPCWoman npcwoman => GetComponentInParent<NPCWoman>();
    void Start()
    {

    }
    void AnimationTrigger()
    {
        npcwoman.AnimationTrigger();
    }
}