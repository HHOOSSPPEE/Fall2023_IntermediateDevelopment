using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image BossHealthBar;
    public Image PlayerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        BossHealthBar.fillAmount = FindObjectOfType<NightmareController>().hp / FindObjectOfType<NightmareController>().i_hp;
        PlayerHealthBar.fillAmount = FindObjectOfType<PlayerController>().hp / FindObjectOfType<PlayerController>().i_hp;
    }
}
