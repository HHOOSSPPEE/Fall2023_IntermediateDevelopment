using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParticle : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    private GameObject _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = Instantiate(particleSystemPrefab,transform.position, transform.rotation);
        _particleSystem.transform.SetParent(gameObject.transform);
        _particleSystem.GetComponent<ParticleSystem>().Stop(false,ParticleSystemStopBehavior.StopEmitting);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            _particleSystem.GetComponent<ParticleSystem>().Play();
            Debug.Log(_particleSystem);
        }
    }
}
