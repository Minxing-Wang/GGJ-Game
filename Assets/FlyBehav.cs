using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehav : MonoBehaviour
{

    Vector3 displacement = new Vector3(2, 2, 2);
    float desplVel = 1;

    private Vector3 pos0;
    public Rigidbody rb;

    private float iniRndX;
    private float iniRndY;
    private float iniRndZ;

  //  private bool audioOn = false;

    private int audioSourceMax = 4;

    private int audioSourceCurr = 0;

    void Start()
    {
        iniRndX = Random.Range(Random.Range(00.0f, 2.0f), 5.0f);
        iniRndY = Random.Range(Random.Range(00.0f, 2.0f), 5.0f);
        iniRndZ = Random.Range(Random.Range(00.0f, 2.0f), 50f);

        desplVel *= Random.Range(5f, 20f);

        rb = GetComponent<Rigidbody>();

        pos0 = transform.localPosition;
        transform.localEulerAngles = new Vector3(
            Random.Range(1f, 90f),
            Random.Range(1f, 90f),
            Random.Range(1f, 90f));
    }

    void Update()
    {

        //// Delete this Lines if you haven't an Audio Source attached to the GameObject
        //        if (!audioOn)
        //        {
        //            if (Random.value < 0.01f)
        //            {
        //                if (CheckAudioSourcesMax())
        //                {
        //                    go.GetComponent<audio>.Play();
        //                    audioOn = true;
        //                }
        //                else
        //                {
        //                    audio.enabled = false;
        //                    audioOn = true;
        //                }
        //            }
        //        }
        //        ////
        //    }
    }

    void FixedUpdate()
    {
        UpdateDespl();
    }

    void UpdateDespl()
    {

               float x = (float) (Mathf.PerlinNoise(Time.time * desplVel + iniRndX, iniRndX) - 0.46525) * displacement.x;
               float y = (float) (Mathf.PerlinNoise(iniRndY, iniRndY + Time.time * desplVel) - 0.46525) * displacement.y;
               float z = (float) (Mathf.PerlinNoise(iniRndZ, iniRndZ + Time.time * desplVel) - 0.46525) * displacement.z;


        Vector3 despl = new Vector3(x, y, z);
        Quaternion rot = Quaternion.LookRotation(despl, Vector3.up);
        rot.eulerAngles = new Vector3(270f, 0f, rot.eulerAngles.y + 90f);

  
        rb.AddForce(despl, ForceMode.Force);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.09f);

        if ((transform.localPosition - pos0).sqrMagnitude > displacement.sqrMagnitude)
        {
            rb.AddForce((pos0 - transform.localPosition) * 100, ForceMode.Force);
        }
    }

    bool CheckAudioSourcesMax()
    {
        int maxNum = 0;
        FlyBehav[] flyScripts = FindObjectsOfType(typeof(FlyBehav)) as FlyBehav[];
        foreach (FlyBehav flyScript in flyScripts)
        {
            maxNum = Mathf.Max(flyScript.IncreaseAudioSourcesCurr(), maxNum);
        }
        if (maxNum <= audioSourceMax) return true;
        else return false;
    }

    int IncreaseAudioSourcesCurr()
    {
        audioSourceCurr++;
        return audioSourceCurr;
    }
}
