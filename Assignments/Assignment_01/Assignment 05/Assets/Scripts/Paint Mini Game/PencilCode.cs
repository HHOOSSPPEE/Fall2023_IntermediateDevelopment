using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilCode : MonoBehaviour
{
    Coroutine drawing;
    public GameObject pencilTool;
    public ColorPicking clrpicking;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();

        }
    }

    void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());


    }

    void FinishLine()
    {
        StopCoroutine(drawing);
        //gameObject.SetActive(false);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(pencilTool, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites-Default"));
        line.colorGradient = clrpicking.gradient;
        


        line.positionCount = 0;
        newGameObject.AddComponent(typeof(PolygonCollider2D));

        

        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }

        

    }
}
