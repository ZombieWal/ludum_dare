using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 originalPosition;
    private bool isMoving = false;
    public float timeToMove = 1f;
    public float movementStep = 0.001f;
    private Vector3 upStep, downStep, leftStep, rightStep;
    public LayerMask noMovementLayer;

    // Start is called before the first frame update
    void Start()
    {
        upStep = new Vector3(0, movementStep, 0);
        downStep = new Vector3(0, -movementStep, 0);
        leftStep = new Vector3(-movementStep, 0, 0);
        rightStep = new Vector3(movementStep, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            Debug.Log("Move down");
            StartCoroutine(MoveDron(downStep));
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            Debug.Log("Move up");
            StartCoroutine(MoveDron(upStep));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            Debug.Log("Move left");
            StartCoroutine(MoveDron(leftStep));
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            Debug.Log("Move right");
            StartCoroutine(MoveDron(rightStep));
        }
    }

    private IEnumerator MoveDron(Vector3 direction)
    {
        float elapsedTime = 0f;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        if (!Physics2D.OverlapCircle(targetPosition, 0.02f, noMovementLayer))
        {
            isMoving = true;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;

            }

            transform.position = targetPosition;

            isMoving = false;
        }
        else
        {
            Debug.Log("There is no way");
        }
    }
}
