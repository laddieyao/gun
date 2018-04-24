using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLineNext : MonoBehaviour
{

    bool iskeydowm = false;
    float time = 0;
    float time1 = 0;
    public KeyCode firekey = KeyCode.Space;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;


    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.02F, 0.02F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
        lineRenderer.useWorldSpace = true;

        //lineRenderer1.material = new Material(Shader.Find("Particles/Additive"));
    }
    void Fire()
    {
        if (Input.GetKey(firekey))
        {
            iskeydowm = true;
        }
    }
    void Update()
    {
        //float time = 0;
        //if (iskeydowm)
        //    time += Time.deltaTime;
        if (Input.GetKey(firekey))
        {
            time1 += Time.deltaTime;
            time = (10 * time1 * 10 * time1);
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            LineRenderer lineRenderer1 = GetComponent<LineRenderer>();
            Vector3 pos = new Vector3(0, 0, 0);
            Vector3 pos1 = new Vector3(50, 0, (100) * ((float)0.5 * time));
            Vector3 pos2 = new Vector3(-50, 0, (100) * ((float)0.5 * time));
            lineRenderer.SetPosition(0, pos1);
            lineRenderer.SetPosition(1, pos);
            lineRenderer.SetPosition(2, pos2);
        }
    }
}
