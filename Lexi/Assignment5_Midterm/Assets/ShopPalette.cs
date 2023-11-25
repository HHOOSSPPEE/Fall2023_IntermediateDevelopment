using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public class ShopPalette : MonoBehaviour
{
    public List<GameObject> purchasedList = new List<GameObject>();
    public TextMeshProUGUI nameDisplayText;
    private GameManager gameManager;
    private TypingText typingText;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        typingText = FindObjectOfType<TypingText>();
    }
    void Update()
    {
        foreach (GameObject obj in purchasedList)
        {
            obj.SetActive(true);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider != null)
        {
            if (typingText.displayObjects.Contains(hitCollider.gameObject))
            {
                Debug.Log(1);
                ShowObjectName(hitCollider.gameObject);
            }
        }

        //else ShowObjectName(null);
    }




        public void AddObject(GameObject target)
    {
        purchasedList.Add(target);
    }

    void ShowObjectName(GameObject obj)
    {
        if (nameDisplayText != null)
        {
            nameDisplayText.text = obj.name;
        }
        else
        {
            //nameDisplayText.text = "";
        }
    }


}
