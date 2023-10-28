using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound : MonoBehaviour
{

    [SerializeField] private AudioSource endTransitionSFX;
    [SerializeField] private AudioSource startTransitionSFX;
    
    public void PlayEnd() { endTransitionSFX.Play(); }

    public void PlayStart() { startTransitionSFX.Play(); }

}
