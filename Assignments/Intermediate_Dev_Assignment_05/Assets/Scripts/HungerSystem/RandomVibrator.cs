using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVibrator : MonoBehaviour
{
    private Vector3 vibrationOrigin;
    public float maxSpeed {  get; private set; }
    public float maxStrength {  get; private set; }
    public float speedPercentage { get; private set; }
    public float strengthPercentage { get; private set; }
    void Awake()
    {
        vibrationOrigin = transform.position;
    }

    void Update()
    {
        float x = vibrationOrigin.x + (Mathf.PerlinNoise(Time.time * speedPercentage * maxSpeed, 0.0f) - .5f) * strengthPercentage * maxStrength;
        float y = vibrationOrigin.y + (Mathf.PerlinNoise(0.0f, Time.time * speedPercentage * maxSpeed) - .5f) * strengthPercentage * maxStrength;
        float z = 0;
        transform.position = new Vector3(x, y, z);
    }

    public void SetMaxSpeed(float speedScale) => this.maxSpeed = Mathf.Max(speedScale, 0);
    public void SetMaxStrength(float strengthScale) => this.maxStrength = Mathf.Max(strengthScale, 0);
    public void SetSpeedPercentage(float speedPercentage) => this.speedPercentage = Mathf.Clamp01(speedPercentage);
    public void SetStrengthPercentage(float strengthPercentage) => this.strengthPercentage = Mathf.Clamp01(strengthPercentage);
    public void ChangeVibrationOrigin(Vector3 vibrationOrigin) => this.vibrationOrigin = vibrationOrigin;
}
