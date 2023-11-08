using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;

    void Start()
    {
        foreach(Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    //find the snap point closet to the draggable
    private void OnDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform closetSnapPoint = null;

        Debug.Log("call");

        //calculate the distance between the draggable object between the snap point
        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closetSnapPoint == null || currentDistance < closestDistance)
            {
                closetSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closetSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closetSnapPoint.localPosition;
            draggable.origionalPosition = closetSnapPoint.localPosition;
            Debug.Log("snap");
        }
    }
}
