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
    public Sprite[] Sprites;
    public int Money = 0;

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
        Banner.Add(new CardData() { CardName = "Crow", CardQuality = "SR", CardProbablity = 175 });
        Banner.Add(new CardData() { CardName = "Deer", CardQuality = "SR", CardProbablity = 175 });
        Banner.Add(new CardData() { CardName = "Foxxy", CardQuality = "SR", CardProbablity = 175 });
        //Banner.Add(new CardData() { CardName = "Insider", CardQuality = "SSR", CardProbablity = 50 });
        Banner.Add(new CardData() { CardName = "Luna", CardQuality = "SSR", CardProbablity = 25 });
        Rbanner = Banner.Where(t => t.CardQuality == "R").ToList();
        SRbanner = Banner.Where(t => t.CardQuality == "SR").ToList();
        SSRbanner = Banner.Where(t => t.CardQuality == "SSR").ToList();

        Sprite apple = Sprites[0];
        Sprite twig = Sprites[1];
        Sprite trash = Sprites[2];
        Sprite Rock = Sprites[3];
        Sprite Leaves = Sprites[4];
        Sprite Bones = Sprites[5];
        Sprite Seeds = Sprites[6];
        Sprite Bug = Sprites[7];
        Sprite Crow = Sprites[8];
        Sprite Deer = Sprites[9];
        Sprite Foxxy = Sprites[10];
        Sprite Luna = Sprites[11];

        Banner[0].CardSprite = Sprites[0];
        Banner[1].CardSprite = Sprites[1];
        Banner[2].CardSprite = Sprites[2];
        Banner[3].CardSprite = Sprites[3];
        Banner[4].CardSprite = Sprites[4];
        Banner[5].CardSprite = Sprites[5];
        Banner[6].CardSprite = Sprites[6];
        Banner[7].CardSprite = Sprites[7];
        Banner[8].CardSprite = Sprites[8];
        Banner[9].CardSprite = Sprites[9];
        Banner[10].CardSprite = Sprites[10];
        Banner[11].CardSprite = Sprites[11];

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
            Image cardImage = go.GetComponent<Image>(); 
            cardImage.sprite = Rbanner[Rcard].CardSprite;

        }
            else if (numBanner <= 150 && numBanner > 50)
            {
            GameObject go = Instantiate(SR);
            go.transform.SetParent(cardsDisplay.transform);

            int SRcard = Random.Range(0, SRbanner.Count);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = SRbanner[SRcard].CardName;
            Image cardImage = go.GetComponent<Image>();
            cardImage.sprite = SRbanner[SRcard].CardSprite;
            //Characters.instance.Storage.Add(new CardData() { CardQuality = "SR", CardName = SRbanner[SRcard].CardName });
        }
            else if (numBanner <= 50)
            {
            GameObject go = Instantiate(SSR);
            go.transform.SetParent(cardsDisplay.transform);
            int SSRcard = Random.Range(0, SSRbanner.Count);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = SSRbanner[SSRcard].CardName;
            Image cardImage = go.GetComponent<Image>();
            cardImage.sprite = SSRbanner[SSRcard].CardSprite;
            Database.CardData.Add(new CardData() { CardQuality = "SSR", CardName = SSRbanner[SSRcard].CardName });
        }
        Money += 1;
        PlayerMoney.text = "Sacrifice: " + Money;
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
                Image cardImage = go.GetComponent<Image>();
                cardImage.sprite = Rbanner[Rcard].CardSprite;

            }
            else if (numBanner <= 150 && numBanner > 50)
            {
                GameObject go = Instantiate(SR);
                go.transform.SetParent(cardsDisplay.transform);

                int SRcard = Random.Range(0, SRbanner.Count);
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = SRbanner[SRcard].CardName;
                Image cardImage = go.GetComponent<Image>();
                cardImage.sprite = SRbanner[SRcard].CardSprite;

            }
            else if (numBanner <= 50)
            {
                GameObject go = Instantiate(SSR);
                go.transform.SetParent(cardsDisplay.transform);
                int SSRcard = Random.Range(0, SSRbanner.Count);
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = SSRbanner[SSRcard].CardName;
                Image cardImage = go.GetComponent<Image>();
                cardImage.sprite = SSRbanner[SSRcard].CardSprite;
                Database.CardData.Add(new CardData() { CardQuality = "SSR", CardName = SSRbanner[SSRcard].CardName });
            }
            Debug.Log(i);
        }
        Money += 5;
        PlayerMoney.text = "Sacrifice: " + Money;
    }
    public void DestoryCards()
    {
        if (cardsDisplay.transform.childCount >= 1)
        {
            for (int i = 0; i < cardsDisplay.transform.childCount; i++)
            {
                Destroy(cardsDisplay.transform.GetChild(i).gameObject);
            }
        }
        Money = 0;
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

                    Insider.GetComponent<Image>().enabled = false;
                    Debug.Log("insider");
                    Debug.Log(Insider.GetComponent<Image>().enabled);


                }
                if (item.CardQuality == "SSR" && item.CardName == "Luna")
                {
                   
                    Luna.GetComponent<Image>().enabled = false;
                    Debug.Log("Luna");
                    Debug.Log(Insider.GetComponent<Image>().enabled);
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
    public Sprite CardSprite;
}