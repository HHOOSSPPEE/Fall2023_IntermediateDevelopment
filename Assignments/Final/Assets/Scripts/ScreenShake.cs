using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    private float shakeDuration;
    private float shakeMagnitude;
    private float shakeFadeout;
    private float shakeRotation;

    public float rotationMultiplier = 15;

    private float randomXrange;
    private float randomYrange;

    private Vector3 OriginalPos = new Vector3(0.5899999f, 0.09999992f, -1.0f);
   
    private void Start()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;

            randomXrange = Random.Range(-0.3f, 0.3f) * shakeMagnitude;
            randomYrange = Random.Range(-0.3f, 0.3f) * shakeMagnitude;

            transform.position += new Vector3(randomXrange, randomYrange, 0);

            shakeMagnitude = Mathf.MoveTowards(shakeMagnitude, 0, shakeFadeout * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0, shakeFadeout * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
        //transform.position = OriginalPos;
    }
    public void TriggerShake (float length, float power)
    {
        shakeDuration = length;
        shakeMagnitude = power;

        shakeFadeout = power / length;

        shakeRotation = power * rotationMultiplier;

    }


}
