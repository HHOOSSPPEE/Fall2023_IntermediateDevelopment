using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    int state = 0;
    float holdingPower = 0f;
    float holdingPowerPerUpdate = 0.01f;
    float maxHoldingPower = 4f;
    Vector3 i_position;
    Vector3 newPosition = new Vector3(3f, -3f, -1f);
    PolygonCollider2D polygonCollider2D;

    void Start()
    {
        i_position = transform.position;
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        polygonCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && (holdingPower < maxHoldingPower))
        {
            if (state == 0)
            {
                state = 1;
            }

            holdingPower += holdingPowerPerUpdate;

            Vector3 newPosition1 = transform.position - Vector3.up * holdingPower * Time.deltaTime;
            transform.position = newPosition1;
            Vector3 newPosition2 = transform.position - Vector3.left * holdingPower/7 * Time.deltaTime;
            transform.position = newPosition2;
        }

        if (!Input.GetKey(KeyCode.Space) && state > 0)
        {
            if (state == 1)
            {
                state = 2;
            }
            holdingPower = 0;
            polygonCollider2D.enabled = false;
            transform.position = newPosition;
        }
    }
}
