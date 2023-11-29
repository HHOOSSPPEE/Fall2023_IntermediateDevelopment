using System.Collections;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject singleObject;
    public GameObject multipleObject;
    public GameObject gameOver;

    bool isSingle = false;

    float firerateSingle = 1.5f;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        isSingle = gameManager.single > gameManager.multiple;

        if (isSingle)
        {
            multipleObject.SetActive(false);
        }
        else
        {
            multipleObject.SetActive(true);
            Multiple multipleScript = multipleObject.GetComponent<Multiple>();
            multipleScript.myType = gameManager.highestElemental;
        }
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(firerateSingle);

            if (isSingle)
            {
                GameObject newSingle = Instantiate(singleObject, transform.position, Quaternion.identity);
                Single single = newSingle.GetComponent<Single>();
                GameManager gameManager = FindObjectOfType<GameManager>();

                single.myType = gameManager.highestElemental;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cultist cultist = collision.gameObject.GetComponent<Cultist>();
        if (cultist != null)
        {
            gameOver.SetActive(true);
        }
    }
}
