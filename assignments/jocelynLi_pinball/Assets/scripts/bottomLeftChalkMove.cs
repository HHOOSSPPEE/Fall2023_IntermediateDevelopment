using UnityEngine;

public class FlipperPhysic : MonoBehaviour
{
    public HingeJoint hinge;
    public float targetPosition;

    public void Down()
    {
        var spring = hinge.spring;
        spring.targetPosition = 0;
        hinge.spring = spring;
    }

    public void Up()
    {
        var spring = hinge.spring;
        spring.targetPosition = targetPosition;
        hinge.spring = spring;
    }
}