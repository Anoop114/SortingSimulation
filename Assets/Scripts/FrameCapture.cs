using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FrameCapture : MonoBehaviour
{
    public string fileName = "TestImage";
    public List<string> frames;
    public List<Texture> textures;
    private void Awake()
    {
        frames = new List<string>();
        textures = new List<Texture>();
        string[] filePaths = Directory.GetFiles(Application.streamingAssetsPath);
        foreach (string filePath in filePaths)
            File.Delete(filePath);
    }
    public void CaptureScreenShot(int num1,int num2)
    {
        DirectoryInfo directoryInfo;
        if (File.Exists(Application.streamingAssetsPath))
        {
            directoryInfo = Directory.CreateDirectory(Application.streamingAssetsPath);

        }
        else
        {
            directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        }
        string fullPath = Path.Combine(directoryInfo.FullName, fileName+num1+""+num2+".png");
        ScreenCapture.CaptureScreenshot(fullPath);

        frames.Add(fullPath);
    }
    
    public void DisplayTexture()
    {
        foreach(string frame in frames)
        {
            byte[] bytes = File.ReadAllBytes(frame);
            Texture2D texture = new(900, 900, TextureFormat.RGB24, false)
            {
                filterMode = FilterMode.Trilinear
            };
            texture.LoadImage(bytes);
            textures.Add(texture);
        }
        
    }
}
