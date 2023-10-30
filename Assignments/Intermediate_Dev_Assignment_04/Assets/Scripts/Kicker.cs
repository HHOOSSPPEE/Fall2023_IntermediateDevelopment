using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    // Start is called before the first frame update
    public float forceScale;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("happends");
            var otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceToPinball = new Vector2(Mathf.Cos(transform.rotation.z + 90), Mathf.Sin(transform.rotation.z + 90)) * forceScale;
            otherRb.AddForce(forceToPinball,ForceMode2D.Impulse);
        }
    }
}
