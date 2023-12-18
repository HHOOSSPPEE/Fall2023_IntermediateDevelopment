using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFont : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject font;
    public GameObject otherFont;

    private GameObject useThis;
    private GameObject notThis;

    private bool fontSwitch = true;

    private GameObject current;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (fontSwitch)
        {
            useThis = font;
            notThis = otherFont;
        }
        else if (!fontSwitch)
        {
            useThis = otherFont;
            notThis = font;
        }
    }

    public void OnButtonClick()
    {
        if (current != null)
        {
            Destroy(current);
        }
        
        current = Instantiate(useThis);
        fontSwitch = !fontSwitch;
    }
}
