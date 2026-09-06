using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{

    private Vector3 MouseScreenPos;
    private float angle;
    private Vector2 direction;

    private float offset;

    //obj
    [SerializeField]
    private GameObject bullet;
    private Transform directionTransform;

    void Start()
    {
        directionTransform = transform.GetChild(0);
        offset = -90f;
    }

    // Update is called once per frame
    void Update()
    {
        MouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseScreenPos.z = 0f;

        direction = MouseScreenPos - transform.position;
        angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + offset;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            fireBullet();
        }
    }

    private void fireBullet()
    {
        Instantiate(bullet, directionTransform.position, Quaternion.Euler(0, 0, angle));
    }
}
