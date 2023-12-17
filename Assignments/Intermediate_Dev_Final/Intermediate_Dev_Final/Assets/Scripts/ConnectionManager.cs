using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Bennet;

public class ConnectionManagera : MonoBehaviour
{
	// Dont worry about this, it's mostly boilerplate
	// 98% is taken from the unity docs, i've tweaked it
	// to allow local testing without the relay key if you set
	// local test to true and set the selected Transport to
	// Unity Transport instead of Unity Relay Transport.
	// todo update for use with Unity Lobby?

	public bool localTest;

	public TMP_InputField joinCodeInputField;

    [SerializeField] private GameObject joinCodeTextBox;
    [SerializeField] private TextMeshProUGUI joinCodeText;
    [SerializeField] private GameObject joinCodeInputFieldObj;

	public bool hosting;
	public string joinCode;


	// Start is called before the first frame update
	private async void Start()
	{
        await UnityServices.InitializeAsync();
		await AuthenticationService.Instance.SignInAnonymouslyAsync();
        joinCodeTextBox.SetActive(false);
    }

	public void JoinGame()
	{
		if (localTest)
		{
			NetworkManager.Singleton.StartClient();
			return;
		}
		string code = joinCodeInputField.text;
		JoinRelay(code);
	}
	public void StartGame()
	{
		if (localTest)
		{
			NetworkManager.Singleton.StartHost();
			NetworkManager.Singleton.SceneManager.LoadScene("WaitingRoom", LoadSceneMode.Single);
			return;
		}
		CreateRelay();
	}

    public void EndGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
	}
	private async void CreateRelay()
	{
		try
		{
			Allocation alloc = await RelayService.Instance.CreateAllocationAsync(1);

			joinCode = await RelayService.Instance.GetJoinCodeAsync(alloc.AllocationId);
			//LocalGame.joinCode = joinCode;

			joinCodeInputFieldObj.SetActive(false);
			joinCodeTextBox.SetActive(true);
			joinCodeText.text = "Join Code: <color=#FF0000>" + joinCode + "</color>";
			

			RelayServerData relayServerData = new RelayServerData(alloc, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

			NetworkManager.Singleton.StartHost();
			NetworkManager.Singleton.SceneManager.LoadScene("WaitingRoom", LoadSceneMode.Single);
		}
		catch (RelayServiceException e)
		{
			Debug.Log(e);
		}

	}

	private async void JoinRelay(string joinCode)
	{
		try
		{
			JoinAllocation jalloc = await RelayService.Instance.JoinAllocationAsync(joinCode);

			RelayServerData relayServerData = new RelayServerData(jalloc, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

			NetworkManager.Singleton.StartClient();
		}
		catch (RelayServiceException e)
		{
			Debug.Log(e); 
		}
	}

}
