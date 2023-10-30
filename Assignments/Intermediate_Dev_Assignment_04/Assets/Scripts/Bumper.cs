using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force = 10;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pinball")
        {
            var _pinballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 bumpingForce = (_pinballRb.position - _rb.position).normalized;
            _pinballRb.AddForce(bumpingForce * force, ForceMode2D.Impulse);
        }
    }
}
