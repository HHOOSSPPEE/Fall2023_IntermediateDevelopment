using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartcleBurst : MonoBehaviour
{
    public static PartcleBurst instance;
    [SerializeField] private Transform Target;
    public bool isActive;

    private void Start()
    {
       
        isActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {

        if (Target)
        {
            Vector2 direction = (Target.position - transform.position).normalized;
        }

        if (Input.GetButton("Fire1"))
        {
            gameObject.SetActive(true);
        }

    }
}
