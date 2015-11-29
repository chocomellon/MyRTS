using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public GameObject objTarget;
    public Vector3 offset;
    private Vector3 fWheelPos;

    void Start()
    {
        updatePostion();
    }

    void LateUpdate()
    {
        updatePostion();

    }

    void updatePostion()
    {
        Vector3 pos = objTarget.transform.localPosition;
        float fWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 fWheelpos=new Vector3 (0, 0, fWheel*4);
        fWheelPos += fWheelpos;
        transform.localPosition = pos + offset+fWheelPos;
    }
}
