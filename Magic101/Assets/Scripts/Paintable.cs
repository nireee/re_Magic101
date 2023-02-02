//using OpenCvSharp.Demo;
using System.Collections;
using System.IO;
using UnityEngine;

public class Paintable : MonoBehaviour
{

    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    public Texture2D texture2D;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
            }

        }
    }

    public void Save()
    {
        StartCoroutine(CoSave());
    }

    private IEnumerator CoSave()
    {
        //wait for rendering
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/savedImage.png");

        //set active texture
        RenderTexture.active = RTexture;

        //convert rendering texture to texture2D
        this.texture2D = new Texture2D(RTexture.width, RTexture.height);
        this.texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        this.texture2D.Apply();
        //Invoke("test", 1);
        test();
        //write data to file
        //var data = texture2D.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);


    }

    private void test()
    {
        //ContoursByShapeScript.Instance.check(this.texture2D);

    }
}