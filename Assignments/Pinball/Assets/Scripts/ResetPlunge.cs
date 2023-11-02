using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlunge : MonoBehaviour
{
    public Transform ballLauncher;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ballLauncher.position = new Vector3(2.98f, -4.688f, 0f);
    }

}
