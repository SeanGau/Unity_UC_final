﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMapper : MonoBehaviour
{
    
    public Transform target;
    private Transform player;
    private Transform indi;

    public GameObject smallMap;
    public GameObject bigMap;
    private bool toggleMap = false;
    private LineRenderer lr;
    
    private void Start()
    {
        player = GameManager.playerCar.transform;
        indi = player.Find("MapIndicator").transform;
        lr = indi.gameObject.GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        lr.SetPositions(new Vector3[]{ target.position, player.position});
        
        //Vector3 mousepos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //float angle = Mathf.Atan((mousepos.y-0.5f) / (mousepos.x-0.5f))* Mathf.Rad2Deg;
        //print("mouse: " + mousepos + " angle: "+ angle);

        if (Input.GetKeyDown(KeyCode.M))
        {
            smallMap.SetActive(toggleMap);
            toggleMap = !toggleMap;
            float lwidth = toggleMap ? 10f:1.5f;
            float msize = toggleMap ? 250f : 50f;
            indi.localScale = Vector3.one * msize;
            lr.startWidth = lr.endWidth = lwidth;
            bigMap.SetActive(toggleMap);
        }
    }
}
