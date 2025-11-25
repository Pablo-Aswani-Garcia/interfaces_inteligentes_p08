using System;
using UnityEngine;

public class TV : MonoBehaviour
{
    private Material TvMaterial;
    int capturecount=1;
    public string device;
    public Renderer render;
        WebCamTexture webcamTexture ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var devices = WebCamTexture.devices;
        device = devices[0].name;
        
        Debug.Log("Using webcam: " + device);
        render = GetComponent<Renderer>();
        TvMaterial = render.material;
        webcamTexture = new WebCamTexture(device);
        render.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (webcamTexture != null)
        {
            if (Input.GetKeyDown(KeyCode.S) && !webcamTexture.isPlaying) webcamTexture.Play();
            if (Input.GetKeyDown(KeyCode.P) && webcamTexture.isPlaying) webcamTexture.Stop();
            if (Input.GetKeyDown(KeyCode.X))
            {
                Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
                snapshot.SetPixels(webcamTexture.GetPixels());
                snapshot.Apply();
                System.IO.File.WriteAllBytes("./" + capturecount + ".png", snapshot.EncodeToPNG());
                capturecount++;

        }
        }
    }


}
