using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingRoom : MonoBehaviour
{
    public void EnterDrawingScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene("Drawing", LoadSceneMode.Single);
    }
}
