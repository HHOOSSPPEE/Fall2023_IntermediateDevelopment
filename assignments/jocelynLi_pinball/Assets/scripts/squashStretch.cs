using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squashStretch : MonoBehaviour
{
    public void squash(GameObject target)
    {
        StartCoroutine(SceneWait(0.3f, target));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("leftBot"))
        {

        }
        else
        {
            collision.gameObject.transform.localScale += new Vector3(0.2f, 0, 0.2f);
            squash(collision.gameObject);
        }
       

    }

    public IEnumerator SceneWait(float waitTime, GameObject target)
    {
      
            yield return new WaitForSeconds(0.2f);
            target.transform.localScale -= new Vector3(0.2f, 0, 0.2f);
            Debug.Log("working");
       

    }

}
