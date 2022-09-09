using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextureImages : MonoBehaviour
{
    public FrameCapture displayImages;
    public RawImage texture;
    public Slider timeSilder;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(StartDisplaying), 2f);
        
    }

    private void StartDisplaying()
    {
        DisplayBubbleShortData();
        timeSilder.minValue = 0;
    }

    public void DisplayBubbleShortData()
    {
        StartCoroutine(DisplayBubbleShortResult());
    }

    private IEnumerator DisplayBubbleShortResult()
    {
        int num = displayImages.textures.Count;
        timeSilder.maxValue = num;
        int i = (int)timeSilder.value;
        while (i < num)
        {
            yield return new WaitForSeconds(.2f);
            texture.texture = displayImages.textures[i];
            i++;
            timeSilder.value = i;
        }
    }
}
