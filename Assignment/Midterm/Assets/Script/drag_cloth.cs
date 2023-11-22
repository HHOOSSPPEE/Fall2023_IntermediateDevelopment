using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class drag_cloth : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickupClip, dropClip;

    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallback;

    public GameObject inbowl_object;
    public List<GameObject> DoNotActive_object;

    private bool dragging;

    public Vector2 offset, origionalPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        origionalPosition = transform.position;
    }

    private void Update()
    {
        if (!dragging) return;

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    //snap to origional position
    private void OnMouseUp()
    {
        //transform.position = origionalPosition;
        dragging = false;
        //dragEndedCallback(this);

    }

    private void OnMouseDown()
    {
        dragging = true;
        //source.PlayOneShot(pickupClip);

        offset = GetMousePos() - (Vector2)transform.position;

    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
