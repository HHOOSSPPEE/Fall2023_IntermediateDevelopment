using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVibrator : MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField] private float vibrationSpeedMultiplier;
    [SerializeField] private float vibrationStrengthMultiplier;
    public float vibrationSpeed { get; set; }
    public float vibrationStrength { get; set; }
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = _initialPosition.x + Mathf.PerlinNoise(Time.time * vibrationSpeed * vibrationSpeedMultiplier, 0.0f) * vibrationStrength * vibrationStrengthMultiplier;
        float y = _initialPosition.y + Mathf.PerlinNoise(0.0f, Time.time * vibrationSpeed * vibrationSpeedMultiplier) * vibrationStrength * vibrationStrengthMultiplier;
        float z = 0;
        transform.position = new Vector3(x, y, z);
    }
}
