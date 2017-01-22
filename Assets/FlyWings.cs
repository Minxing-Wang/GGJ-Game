using UnityEngine;
using System.Collections;

public class FlyWings : MonoBehaviour
{

    public Transform wings;
    float freq = 12;
    private float upSize = 1;

    private float downSize = -0.5f;

    void Update()
    {
        float range = upSize - downSize;
        float currSize = Mathf.PingPong(Time.time * freq, 1) * range + downSize;
        wings.localScale = new Vector3(wings.localScale.x, wings.localScale.y, currSize);
    }
}