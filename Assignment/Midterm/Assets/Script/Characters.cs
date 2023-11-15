using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class Characters : MonoBehaviour
{
    public static Characters instance;
    public List<CardData> Storage = new List<CardData>();
    public GameObject SSR;
    public GameObject Insider;
    public GameObject Luna;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Storage = new List<CardData>();
       
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
