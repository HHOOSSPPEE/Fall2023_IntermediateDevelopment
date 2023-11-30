using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    [SerializeField] private GameObject batEffectBatPrefab;
    [SerializeField] private int dashEffectBatsCount = 10;
    [SerializeField] private float lifeTime = 1.0f;
    void Start()
    {
        for (int i = 0; i < dashEffectBatsCount; i++)
        {
            var bat= Instantiate(batEffectBatPrefab);
            bat.transform.position = transform.position;
            bat.GetComponent<RandomBat>().lifeTime = lifeTime;
        }
        StartCoroutine("SelfDestroy");
    }
    IEnumerable SelfDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this);
    }
}
