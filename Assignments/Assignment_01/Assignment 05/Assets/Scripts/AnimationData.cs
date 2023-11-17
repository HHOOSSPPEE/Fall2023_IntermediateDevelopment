using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation Data", menuName ="Scriptable Objects/Animation Data",order = 1)]
public class AnimationData : ScriptableObject
{
    public Sprite[] sprite;
    public int framesOfGap;
    public static float targetFrameTime = 0.0167f;
    public bool loop;

}
