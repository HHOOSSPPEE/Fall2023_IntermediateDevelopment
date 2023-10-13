using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    private List<WaveScript> springs = new();

    public float force = 0;
    public float velocity = 0;
    public float height = 0f;
    public float targetHeight = 0;


    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;
    Vector2 currentVelocity;

    //public float dampen = 0f;
    //public float springStiff = 0f;
    

    public void ParticleSpringUpdate(float springStiff, float dampen)
    {
        
        height = transform.localPosition.y;
        //as high as it can go
        var x = height - targetHeight;
        var loss = -dampen * velocity;
        force = -springStiff * x + loss;
        velocity += force;
        var y = transform.localPosition.y;
        transform.localPosition = new Vector3(transform.localPosition.x, y + velocity, transform.localPosition.z);
        targetHeight = 0f;


    }

    void OnMouseOver()
    {
        //Debug.Log("h");
        //make it go back after
        //targetHeight = 2f;
        

        ////mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
        //transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);

    }

    private void OnMouseUp()
    {
        //Vector2 mousePosition = Input.mousePosition;
        //height = mousePosition.y;
        targetHeight = 2f;
        Debug.Log("down");
        
    }

}
