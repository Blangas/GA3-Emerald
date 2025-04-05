using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from "How to Create a Top Down Movement Character Controller in Unity | Scripting Tutorial"
// https://www.youtube.com/watch?v=-0GFb9l3NHM

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera camer;

    private void Awake()
    {   _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {   // converts Vector2 to Vector3
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        MoveTowardTarget(targetVector);

        RotateTowardMouseVector();
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, camer.gameObject.transform.eulerAngles.y, 0) * targetVector;
        transform.Translate(targetVector * speed);
    }

    private void RotateTowardMouseVector()
    {
        Ray ray = camer.ScreenPointToRay(_input.MousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}
