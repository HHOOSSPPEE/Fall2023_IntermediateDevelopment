using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Rigidbody2D _rb;
    public KeyCode controllKey;
    public float torqueScale = 10.0f;
    public FlipperType type;
    public enum FlipperType { LeftFlipper, RightFlipper };
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (type == FlipperType.LeftFlipper)
            controllKey = GameObject.Find("Game Manager").GetComponent<GameManager>().leftFlipperControllKey;
        if (type == FlipperType.RightFlipper)
        {
            controllKey = GameObject.Find("Game Manager").GetComponent<GameManager>().rightFlipperControllKey;
            torqueScale = -torqueScale; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(controllKey))
        {
            _rb.AddTorque(torqueScale, ForceMode2D.Force);
        }
        else
        {
             _rb.AddTorque(-torqueScale, ForceMode2D.Force);
        }
    }
}
