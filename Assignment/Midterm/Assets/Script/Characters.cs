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

    /*public void CharacterList()
    {
        Gacha gacha = FindObjectOfType<Gacha>();
        Storage = gacha.Storage;
        

        foreach (var item in Database.CardData)
        {
            if (Database.CardData.Count != 0)
            {
                if (item.CardQuality == "SSR" && item.CardName == "Insider")
                {
                    
                    //Destroy(Insider.GetComponent<SpriteRenderer>());
                    
                    Insider.transform.position = new Vector3(1000f, 1000f, 0f);
                    Debug.Log(Insider.transform.position);
                }
                if (item.CardQuality == "SSR" && item.CardName == "Luna")
                {
                    
                    //Destroy(Luna.GetComponent<SpriteRenderer>());
                    Luna.transform.position = new Vector3(1000f, 1000f, 0f);
                    Debug.Log(transform.position);
                }
            }
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
