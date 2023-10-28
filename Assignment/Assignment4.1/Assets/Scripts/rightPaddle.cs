using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightpaddleControl : MonoBehaviour
{
    public Animator rightPaddleAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rightPaddleAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightPaddleAnimator.ResetTrigger("Pressed");
            rightPaddleAnimator.SetTrigger("Pressed");
        }
    }
}
