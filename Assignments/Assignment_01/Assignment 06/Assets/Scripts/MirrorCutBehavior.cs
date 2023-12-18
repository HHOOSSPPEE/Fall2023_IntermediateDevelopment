using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCutBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationTestBehavior test;
    public PlayerController plyr;
    public GameObject blood;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test.animationDone == true)
        {
            blood.SetActive(true);
            plyr.useRosary = false;
        }
    }

}
