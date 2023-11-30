using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    void Update()
    {
        if (!PlayerMovementController.Instance.GetIsDashing()) transform.SetParent(null, true);
    }
}
