using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio : MonoBehaviour
{
    public AudioClip clickSound; // ����Ч�ļ��Ϸŵ�����

    private AudioSource audioSource;

    void Start()
    {
        // ��ȡ��ť�ϵ� AudioSource ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // �����ť��û�� AudioSource ����������һ��
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ������Ч
        audioSource.clip = clickSound;
    }

    // ����ť������ʱ����
    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickSound != null)
        {
            // ������Ч
            audioSource.PlayOneShot(clickSound);
        }
    }
}
