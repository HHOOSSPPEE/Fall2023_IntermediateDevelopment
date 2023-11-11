using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Gacha : MonoBehaviour
{
    int numBanner = 0;
    public static Characters instance;
    public List<CardData> Storage = new List<CardData>();
    public GameObject R;
    public GameObject SR;
    public GameObject SSR;
    public GameObject cardsDisplay;
    public TMP_Text PlayerMoney;
    public GameObject Insider;
    public GameObject Luna;
    public int Money = 6000;

    // Start is called before the first frame update
    List<CardData> Banner = new List<CardData>();
    List<CardData> PlayerBanner = new List<CardData>();
    List<CardData> Rbanner;
    List<CardData> SRbanner;
    List<CardData> SSRbanner;
    void Start()
    {
        Banner.Add(new CardData() { CardName = "Apple", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Twig", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Trash", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Rock", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Leaves", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Bones", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Seeds", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Bug", CardQuality = "R", CardProbablity = 800 });
        Banner.Add(new CardData() { CardName = "Crow", CardQuality = "SR", CardProbablity = 150 });
        Banner.Add(new CardData() { CardName = "Deer", CardQuality = "SR", CardProbablity = 150 });
        Banner.Add(new CardData() { CardName = "Foxxy", CardQuality = "SR", CardProbablity = 150 });
        Banner.Add(new CardData() { CardName = "Ghost", CardQuality = "SR", CardProbablity = 150 });
        Banner.Add(new CardData() { CardName = "Insider", CardQuality = "SSR", CardProbablity = 50 });
        Banner.Add(new CardData() { CardName = "Luna", CardQuality = "SSR", CardProbablity = 50 });
        Rbanner = Banner.Where(t => t.CardQuality == "R").ToList();
        SRbanner = Banner.Where(t => t.CardQuality == "SR").ToList();
        SSRbanner = Banner.Where(t => t.CardQuality == "SSR").ToList();
    }
     
    public void GatchaOnce ()
    {
        //r 50% sr 42% ssr 8%
        if (cardsDisplay.transform.childCount >= 1)
        {
            for(int i = 0; i<cardsDisplay.transform.childCount; i++)
            {
                Destroy(cardsDisplay.transform.GetChild(i).gameObject);
            }
        }
            numBanner = Random.Range(0, 1000);
        if (numBanner > 150)
        {
            GameObject go = Instantiate(R);
            go.transform.SetParent(cardsDisplay.transform);
            int Rcard = Random.Range(0, Rbanner.Count);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = Rbanner[Rcard].CardName;
           
           
        }
            else if (numBanner <= 150 && numBanner > 50)
            {
            GameObject go = Instantiate(SR);
            go.transform.SetParent(cardsDisplay.transform);

            int SRcard = Random.Range(0, SRbanner.Count);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = SRbanner[SRcard].CardName;
            //Characters.instance.Storage.Add(new CardData() { CardQuality = "SR", CardName = SRbanner[SRcard].CardName });
        }
            else if (numBanner <= 50)
            {
            GameObject go = Instantiate(SSR);
            go.transform.SetParent(cardsDisplay.transform);
            int SSRcard = Random.Range(0, SSRbanner.Count);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = SSRbanner[SSRcard].CardName;
            Database.CardData.Add(new CardData() { CardQuality = "SSR", CardName = SSRbanner[SSRcard].CardName });
        }
        Money -= 600;
        PlayerMoney.text = "Money: " + Money;
    }
    public void GatchaFive()
    {
        if (cardsDisplay.transform.childCount >= 1)
        {
            for (int i = 0; i < cardsDisplay.transform.childCount; i++)
            {
                Destroy(cardsDisplay.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < 5; i++)
        {
            numBanner = Random.Range(0, 1000);
            if (numBanner > 150)
            {
                GameObject go = Instantiate(R);
                go.transform.SetParent(cardsDisplay.transform);
                int Rcard = Random.Range(0, Rbanner.Count);
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = Rbanner[Rcard].CardName;
                

            }
            else if (numBanner <= 150 && numBanner > 50)
            {
                GameObject go = Instantiate(SR);
                go.transform.SetParent(cardsDisplay.transform);

                int SRcard = Random.Range(0, SRbanner.Count);
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = SRbanner[SRcard].CardName;
                
            }
            else if (numBanner <= 50)
            {
                GameObject go = Instantiate(SSR);
                go.transform.SetParent(cardsDisplay.transform);
                int SSRcard = Random.Range(0, SSRbanner.Count);
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = SSRbanner[SSRcard].CardName;
                Database.CardData.Add(new CardData() { CardQuality = "SSR", CardName = SSRbanner[SSRcard].CardName });
            }
            Debug.Log(i);
        }
        Money -= 3000;
        PlayerMoney.text = "Sacrifice: " + Money;
    }
    public void CharacterList()
    {
        Gacha gacha = FindObjectOfType<Gacha>();
        Storage = gacha.Storage;


        foreach (var item in Database.CardData)
        {
            if (Database.CardData.Count != 0)
            {
                Debug.Log("count");
                if (item.CardQuality == "SSR" && item.CardName == "Insider")
                {
                    Debug.Log("insider");

                    //Destroy(Insider.GetComponent<SpriteRenderer>());
                    Insider.GetComponent<Image>().enabled = false;

                    //Debug.Log(Insider.transform.position);
                }
                if (item.CardQuality == "SSR" && item.CardName == "Luna")
                {

                    //Destroy(Luna.GetComponent<SpriteRenderer>());
                    Luna.GetComponent<Image>().enabled = false;
                    //Luna.transform.position = new Vector3(1000f, 1000f, 0f);
                    //Debug.Log(transform.position);
                }
            }
        }
    }
}



    // Update is called once per frame
    

public class CardData
{
    public string CardQuality;
    public string CardName;
    public int CardProbablity;
}