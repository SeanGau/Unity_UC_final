﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] carSets;
    public static GameObject playerCar;
    public static float startTime;
    private void Awake()
    {
        int _nowCar = CarShowCamera.nowCar;
        playerCar = Instantiate(carSets[_nowCar], new Vector3(50, 1, 0), new Quaternion(0, 0, 0, 0));
        playerCar.SetActive(true);
    }

    private void Start()
    {
        startTime = Time.time;
    }
}
