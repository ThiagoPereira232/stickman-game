using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;

    private Transform cam;

    public float ParallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance =  ParallaxEffect;
        transform.position += new Vector3(startPos + Distance,0, 0) * ParallaxEffect * Time.deltaTime;
        if (RePos > startPos + length)
        {
            startPos += length;
        }
        else if(RePos < startPos - length)
        {
            startPos -= length;
        }
    }
}
