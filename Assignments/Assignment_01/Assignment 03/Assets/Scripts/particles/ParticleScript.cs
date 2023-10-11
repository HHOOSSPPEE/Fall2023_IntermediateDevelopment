using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using static UnityEngine.ParticleSystem;

public class ParticleScript : MonoBehaviour
{
    public bool _par;
    public string particle_object;

    private ParticleSystem ps;


    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
        var emitParams = ps.emission;
        var parShape = ps.shape;
        
        emission.rateOverTime = 0.0f;
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
        var parShape = ps.shape;

        var emission = ps.emission;
        //parShape.position = mousePos;
        //var emitParams = new ParticleSystem.EmitParams();




        if (Input.GetMouseButton(0))
        {
            Debug.Log(mousePos);
            emission.rateOverTime = 10.0f;
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.position = mousePos;


        }
        else
        {
            emission.rateOverTime = 0.0f;
        }

    }

}
