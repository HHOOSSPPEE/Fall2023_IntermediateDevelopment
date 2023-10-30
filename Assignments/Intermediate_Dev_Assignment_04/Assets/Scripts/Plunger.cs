using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    public float power = 0;
    public float maxPower = 1f;
    public float accumulationRate = .5f;
    public Slider slider;
    public float lerpSpeed = 1.0f;
    public KeyCode controllKey;
    private float xPosistion;
    private Rigidbody2D _rb;
    private Rigidbody2D _rbPinball;
    private bool _launched = false;
    private Vector2 _force;
    private bool _accumulated;
    private bool gameStarted = false;
    void Start()
    {
        controllKey = GameObject.Find("Game Manager").GetComponent<GameManager>().plungerControllKey;
        _rb = GetComponent<Rigidbody2D>();
        xPosistion = transform.position.x;
        slider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = power; 
        if (Input.GetKey(controllKey))
        {
            if (power < maxPower)
                power += accumulationRate * Time.deltaTime;
            _accumulated = true;
        }
        else
        {
            power = Mathf.Lerp(power, 0, lerpSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(controllKey))
        {
            _launched = false;
            _force = new Vector2(0, power);
        }
        slider.value = power;
        if (_accumulated && !_launched && power < 0.1f)
        {
            if (_rbPinball != null)
            {
                _rbPinball.AddForce(_force, ForceMode2D.Impulse);
            }
            _launched = true;
            _accumulated = false;
        }
        /*
        if (lerpingSlider)
        {
            slider.value = Mathf.Lerp(slider.value, 1f, lerpSpeed * Time.deltaTime);

            if (slider.value >= 0.999f)
            {
                slider.value = 1f;
                lerpingSlider = false;
            }
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _rbPinball = collision.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _rbPinball = null;
    }
}
