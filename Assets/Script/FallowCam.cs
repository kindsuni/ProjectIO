using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCam : MonoBehaviour
{
    public GameObject player;
    public Transform Target;
    public float Distance = 20f;
    public float Height = 10f;
    public float dampTrace = 20.0f;

    private Transform tr;

    void Start()
    {
        player = GameObject.Find("Player");
        Target = player.transform;
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tr.position = Vector3.Lerp(tr.position
            , Target.position
            - (Target.forward * Distance)
            + (Vector3.up * Height)
            , Time.deltaTime * dampTrace);
        tr.LookAt(Target.position);
    }
}