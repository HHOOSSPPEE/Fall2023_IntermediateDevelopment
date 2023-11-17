using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public AnimationData baseAnimation;
    Coroutine previousAnimation;


    private void Start()
    {
        PlayAnimation(baseAnimation);
    }

    public void PlayAnimation(AnimationData data)
    {
        if (previousAnimation != null)
        
            StopCoroutine(previousAnimation);
        
            previousAnimation = StartCoroutine(PlayAnimationCoroutine(data));
    }

    public IEnumerator PlayAnimationCoroutine(AnimationData data)
    {
        if (data == null)
        {
            data = baseAnimation;
        }
        int spritesAmount = data.sprite.Length, i = 0;
        
        float waitTime = data.framesOfGap * AnimationData.targetFrameTime;
        
        while (i < spritesAmount)
        {
            mySpriteRenderer.sprite = data.sprite[i++];
            yield return new WaitForSeconds(waitTime);

            if (data.loop && i>=spritesAmount)
            {
                i = 0;
            }

        }
        yield return null;

    }
}
