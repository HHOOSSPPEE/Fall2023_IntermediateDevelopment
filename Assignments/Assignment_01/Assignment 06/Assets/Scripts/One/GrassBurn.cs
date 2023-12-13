using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


[RequireComponent(typeof(AudioSource))]
public class GrassBurn : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;
    public AudioClip clip;
    private bool audioDone = false;
    public HexagonalRuleTile tile;
    public GameObject fiery;
    public GameObject grassburn;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioDone && !audio.isPlaying)
        {
            audio.clip = clip;
            audio.Play(0);
            audio.loop = false;
            audioDone = false;
            fiery.SetActive(true);
            grassburn.SetActive(true);
            //tile.GetTileData
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && !audioDone)
        {
            audio.Play(0);

            audioDone = true;
        }


    }
}
