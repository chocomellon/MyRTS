using UnityEngine;
using System.Collections;

public class MouseControlCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance = 1.0f;

    //追加
    [SerializeField]
    private float zMin;  //マウスホイールで近づける最小距離
    [SerializeField]
    private float zMax; //マウスホイールで離れられる最大距離

    private float x = 0.0f;
    private float y = 0.0f;

    Vector3 angles;
    void Start()
    {
        angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }


    void LateUpdate()
    {
        if (target)
        {

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance*10) + target.position;

            transform.rotation = rotation;
            transform.position = position;


            //以下追加
            //ズームの距離に制限を設ける
            distance -= Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance, zMin, zMax);


        }
    }

}

