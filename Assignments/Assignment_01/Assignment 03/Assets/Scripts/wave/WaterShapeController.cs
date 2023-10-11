using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShapeController : MonoBehaviour
{
    [SerializeField]
    private float springStiff = 0.1f;
    public float dampen = 0.03f;
    [SerializeField]
    private List<WaveScript> springs = new();

    public float spread = 0.005f;


    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;
    Vector2 currentVelocity;


    private void UpdateSprings()
    {
        int count = springs.Count;
        float[] left_deltas = new float[count];
        float[] right_deltas = new float[count];

        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                left_deltas[i] = spread * (springs[i].height - springs[i - 1].height);
                springs[i - 1].velocity += left_deltas[i];
            }
            if (i < springs.Count - 1)
            {
                right_deltas[i] = spread * (springs[i].height - springs[i + 1].height);
                springs[i + 1].velocity += right_deltas[i];
            }
        }
    }

    void FixedUpdate()
    {
        foreach (WaveScript waveScriptComponent in springs)
        { 
            waveScriptComponent.ParticleSpringUpdate(springStiff, dampen);

        }

        UpdateSprings();

    }

    private void Splash(int index, float speed)
    {
        if (index >= 0 && index < springs.Count)
        {
            springs[index].velocity += speed;
        }
    }

    //private void OnMouseOver()
    //{
    //    Debug.Log("h");

    //    Vector2 mousePosition = Input.mousePosition;

    //    mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
    //    transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);

    //}
}
