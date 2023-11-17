using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    void Update()
    {
        if (!PlayerController.instance.GetIsDashing()) transform.SetParent(null, true);
    }
}
