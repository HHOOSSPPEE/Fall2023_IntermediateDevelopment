using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio : MonoBehaviour
{
    public AudioClip clickSound; // 将音效文件拖放到这里

    private AudioSource audioSource;

    void Start()
    {
        // 获取按钮上的 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // 如果按钮上没有 AudioSource 组件，则添加一个
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 设置音效
        audioSource.clip = clickSound;
    }

    // 当按钮被按下时调用
    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickSound != null)
        {
            // 播放音效
            audioSource.PlayOneShot(clickSound);
        }
    }
}
