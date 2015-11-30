using UnityEngine;
using System.Collections;
using System;

public class KongBullet : MonoBehaviour
{
    private Vector3 vDir;
    private DateTime createTime;
    private float fSpeed = 2f;
    private int nDestroyTime = 3;

    // Use this for initialization
    void Start()
    {
        createTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Init(Vector3 _vPos, Vector3 _vDir)
    {
        transform.localPosition = _vPos;
        vDir = _vDir;
    }

    void Move()
    {
        transform.Translate(vDir * fSpeed * Time.deltaTime);

        TimeSpan ts = DateTime.Now - createTime;
        if (ts.Seconds >= nDestroyTime)
        {
            Destroy(gameObject);
        }
    }
}
