using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform lookFrom;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        lookFrom.LookAt(lookAt);
        offset = lookFrom.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(offset.x + 90, (offset.y + 180), offset.z + 180);
    }
}
