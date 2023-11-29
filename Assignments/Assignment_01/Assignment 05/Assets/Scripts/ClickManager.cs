using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
//using static UnityEditor.Progress;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    GameManager gameManager;
    Camera myCamera;
    public bool playerWalking;
    public int goToClickMaxY = 0;
    //public GameObject player;
    //public TileManager tile;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        myCamera = GetComponent<Camera>();
        //tile = GetComponent<TileManager>();

    }

    


    public void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {

            Vector3Int position = new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0);

            //if (GameManager.instance.tileManager.IsInteractable(position))
            //{
            //    Debug.Log("works");
            //}

            StartCoroutine(GoToClick(Input.mousePosition));



        }

        //if (playerWalking)
        //{//place this instead of the bird sprite

        //    Animator walk = pyr.FindObjectOfType<Animator>();
        //    walk.SetBool("walk", true);
        //}
        //else
        //{
            
        //    Animator walk = gameObject.GetComponentInChildren<Animator>();
        //    walk.SetBool("walk", false);
        //}

    }

    

    public IEnumerator GoToClick(Vector2 mousePos)
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("go to point");
        Vector2 targetPos = myCamera.ScreenToWorldPoint(mousePos);
        if (targetPos.y > goToClickMaxY || playerWalking)
        {
            yield break;
        }
        //StartCoroutine(gameManager.MoveToPoint(player, targetPos));
        //playerWalking = true;
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject g in grounds)
            if (g.GetComponent<Collider2D>().OverlapPoint(targetPos))
        {
            Debug.Log("canclickground");
            StartCoroutine(gameManager.MoveToPoint(player, targetPos));
            playerWalking = true;
        }
           
    }

    public void GoToItem(ItemData item)
    {
        //gameManager.UpdateHintBox(null, false);
        Debug.Log("go to item");
        
        StartCoroutine(gameManager.MoveToPoint(player, item.GoToPoint.position));
        player.GetComponent<SpriteAnimator>().PlayAnimation(gameManager.playerAnimations[1]);
        
        TryGettingItem(item);
        
        if (item == FindObjectOfType<MoveBetweenScenes>())
        {
            FindObjectOfType<MoveBetweenScenes>().switchScene();
        }

    }
   
    private void TryGettingItem(ItemData item)
    {
        
            bool canGetItem = item.requiredItemID == -1 || gameManager.selectedItemId == item.requiredItemID;

            if (canGetItem)
            {
                GameManager.collectedItems.Add(item );

            }
            StartCoroutine(UpdateSceneAfterAction(item, canGetItem));
        
       
    }

    private IEnumerator UpdateSceneAfterAction(ItemData item, bool canGetItem)
    {
        while (playerWalking)
            yield return new WaitForSeconds(0.05f);
        //wait for player to reach tagert
        if (canGetItem)
        {
            foreach (GameObject g in item.objectsToRemove)
                Destroy(g);
            //gameManager.UpdateEquipmentCanvas();
            Debug.Log("collected item");
        }
        else
        {
            //gameManager.UpdateHintBox(item, player.GetComponentInChildren<SpriteRenderer>().flipX);
            //Debug.Log("special condition");
            gameManager.CheckSpecialConditions(item);
        }
        player.GetComponent<SpriteAnimator>().PlayAnimation(null);
        yield return null;
    }

}
