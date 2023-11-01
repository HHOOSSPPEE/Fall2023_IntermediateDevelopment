using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerControl : MonoBehaviour
{
    public Animator leftPaddleAnimator;

    // Start is called before the first frame update
    public void Start()
    {
        leftPaddleAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftPaddleAnimator.ResetTrigger("Pressed");
            leftPaddleAnimator.SetTrigger("Pressed");
        }

    }
}
