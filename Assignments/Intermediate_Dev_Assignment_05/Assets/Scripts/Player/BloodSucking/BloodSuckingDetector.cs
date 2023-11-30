using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuckingDetector : MonoBehaviour
{
    private BoxCollider2D detectionCollider;

    public event Action<GameObject> OnEnemyDetected;

    void Start()
    {
        detectionCollider = GetComponent<BoxCollider2D>();
        detectionCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision);

            OnEnemyDetected?.Invoke(collision.gameObject);
            detectionCollider.enabled = false;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.SetTrigger(Enemy.AnimationTrigger.beingSucked);
            }
        }
    }
    public void StartDetection()
    {
        detectionCollider.enabled = true;
        detectionCollider.offset = new Vector2
            (
                PlayerMovementController.Instance.GetFacingDirection() == PlayerMovementController.FacingDirection.Right ? -1f : 1f,
                0
            );
    }
    public void EndDetection()
    {
        detectionCollider.enabled = false;
    }
}
