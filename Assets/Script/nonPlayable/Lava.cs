using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    GameObject lava;
    Vector3 lavaVec;

    float uptime;
    float upheight;
    bool isCoroutine;
    // Start is called before the first frame update

    private void Awake()
    {
        isCoroutine = false;
        lava = this.gameObject;
        lavaVec = lava.transform.position;
        uptime = 2f;

        upheight = 0.25f;

    }

    void Start()
    {
        //StartCoroutine("LavaUp");
    }


    public void StartLavaMove()
    {
        if (!isCoroutine)
        {
            StartCoroutine("LavaUp");
        }
        isCoroutine = true;
    }


    public void StopLavaMove()
    {

        if (isCoroutine)
        {
            StopCoroutine("LavaUp");
        }
        isCoroutine = false;

    }
    IEnumerator LavaUp()
    {

        while (true)
        {
            if (GameManager.Instance.time1 && Time.deltaTime != 0) {
                lavaVec = lava.transform.position;
                lavaVec.y += upheight;
                lava.transform.position  = lavaVec;


            }
            yield return new WaitForSeconds(uptime);
            upheight += 0.001f;
            //Debug.Log("LavaUp");

        }
    }

}
