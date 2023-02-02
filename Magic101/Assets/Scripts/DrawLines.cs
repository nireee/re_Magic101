using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DrawLines : MonoBehaviour
{
    List<Vector3> linepoints;
    float timer;
    public float timerdelay;
    public RenderTexture RTexture;

    GameObject newline;
    LineRenderer drawline;
    public float linewidth;
    // Start is called before the first frame update
    void Start()
    {
        linepoints = new List<Vector3>();
        timer = timerdelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newline = new GameObject();
            drawline = newline.AddComponent<LineRenderer>();
            drawline.material = new Material(Shader.Find("Sprites/Default"));
            drawline.startColor = randomColor();
            drawline.endColor = randomColor();
            drawline.startWidth = 0.1f;
            drawline.endWidth = 0.1f;
        }
        if (Input.GetMouseButton(0)) 
        {
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
            timer -= Time.deltaTime;
            if(timer <= 0) 
            {
                linepoints.Add(GetMousePosition());
                drawline.positionCount = linepoints.Count;
                drawline.SetPositions(linepoints.ToArray());

                timer = timerdelay;
            }
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            linepoints.Clear();
        }
    }

    Vector3 GetMousePosition() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * 10;
    }

    Color randomColor() 
    {
        return Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
    }
    
}
