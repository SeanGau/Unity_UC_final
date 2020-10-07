﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    [Header("靈敏度"), Range(0, 1000)]
    public float mouseSensitivity = 100;
    [Header("攻擊力"), Range(0, 500)]
    public float attack = 20;
    [Header("子彈數量"), Range(0, 500)]
    public float bullet = 200;
    [Header("音效")]
    public AudioClip soundShot;
    [Header("開槍特效")]
    public GameObject MuzzleFlash;
    [Header("子彈")]
    public GameObject Bullet;

    public Transform Gun;
    public Transform Point;
    public Animator ani;
    public AudioSource aud;


    private IEnumerator oneshot()
    {
        var psN = Instantiate(Bullet, Point.position, Point.rotation).GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(1);
        Destroy(psN);
    }

    /// <summary>
    /// 射擊
    /// </summary>
    [System.Obsolete]
    private void shot()
    {
        bool leftmouse = Input.GetKey(KeyCode.Mouse0);
        ani.SetBool("射擊", leftmouse);
        if (Input.GetKey(KeyCode.Mouse0) && !aud.isPlaying)
        {
            aud.PlayOneShot(soundShot, 0.8f);
            MuzzleFlash.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            aud.Stop();
            MuzzleFlash.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(oneshot());
            //ps.loop = true;
            //ps.transform.SetParent(Point);

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            //ps.loop = false;
            //ps.transform.SetParent(null);
        }
    }

    private void Mouse()
    {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 targetPos = new Vector3(mousePos.x - 0.5f,0 ,mousePos.y - 0.5f);
        Gun.forward = targetPos;        
    }

    [System.Obsolete]
    private void Update()
    {
        shot();
        Mouse();
    }
    private void Start()
    {
        
    }
}
