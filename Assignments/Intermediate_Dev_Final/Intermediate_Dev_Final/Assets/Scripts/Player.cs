using Bennet;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Texture2D avatar;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        NetworkObject networkObject = GetComponent<NetworkObject>();
        NetworkTransform networkTransform = GetComponent<NetworkTransform>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(avatar, new Rect(0,0,avatar.width, avatar.height), Vector2.zero);

        Vector3 cameraBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        networkTransform.transform.position = new Vector3(cameraBottomLeft.x, cameraBottomLeft.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (IsHost && Input.GetMouseButtonDown(1))
        {
            textureData.Value = ImageConversion.EncodeToPNG(textureToSend);
        }
        if (!IsHost && textureData.Value != null)
        {
            Tools.LoadTextureFromBytes(textureData.Value, out var texture);
            gameObject.GetComponent<SpriteRenderer>().sprite = texture.CreateSprite();
        }
        */
    }
}
