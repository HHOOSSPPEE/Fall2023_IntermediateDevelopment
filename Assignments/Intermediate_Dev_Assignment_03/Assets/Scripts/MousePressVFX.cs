using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressVFX : MonoBehaviour
{
    private TrailRenderer _mouseTrail;
    private Vector2 _mousePos;
    // Start is called before the first frame update
    void Start()
    {
        _mouseTrail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(_mousePos.x, _mousePos.y, 0f);
            _mouseTrail.Clear();
        }
        if (Input.GetMouseButton(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(_mousePos.x, _mousePos.y, 0f);
        }
    }
}
