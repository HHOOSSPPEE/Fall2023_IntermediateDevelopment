using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickupClip,dropClip;

    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallback;

    public GameObject inbowl_object;
    public List<GameObject> DoNotActive_object;

    public spawn_objects spawnManager;
    private bool dragging;

    private Vector2 offset, origionalPosition;

    public GameObject desiredObject;



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
        transform.position = origionalPosition;
        dragging = false;
        //dragEndedCallback(this);

        if (spawnManager != null)
        {
            spawnManager.OnObjectDropped(this, desiredObject);
        }

    }

    private void OnMouseDown()
    {
        dragging = true;
        //source.PlayOneShot(pickupClip);

        offset = GetMousePos() - (Vector2)transform.position;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            if (spawnManager != null)
            {
                spawnManager.OnObjectDropped(this, desiredObject);
            }
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
