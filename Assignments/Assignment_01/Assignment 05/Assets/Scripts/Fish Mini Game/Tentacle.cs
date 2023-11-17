using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer LineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;


    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir; 



    private void Start()
    {
        LineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        ResetPos();
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
        }
        LineRend.SetPositions(segmentPoses);
    }


    private void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;

        }
        LineRend.SetPositions(segmentPoses);
    }
}
