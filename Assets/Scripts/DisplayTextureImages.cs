using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextureImages : MonoBehaviour
{
    public FrameCapture displayImages;
    public RawImage texture;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        int num = displayImages.textures.Count;
        print(num);
        for(int i = 0; i < num; i++)
        {
            yield return new WaitForSeconds(.2f);
            texture.texture = displayImages.textures[i];
        }
    }
}
