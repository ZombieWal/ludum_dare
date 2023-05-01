using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroneMovement : MonoBehaviour
{
    // where the dron want to move
    private Vector3 targetPosition;
    // save the prev positioning of the drone
    private Vector3 originalPosition;
    // is the dron moving to the next tile
    private bool isMoving = false;
    // how much time the drome moves to the next tile
    public float speed = 10f;
    private float movementStep = 0.16f;
    private Vector3 upStep, downStep, leftStep, rightStep;
    public LayerMask noMovementLayer;
    // do we control the drome movement manually or not
    private bool isUnderControl = true;
    // all drones for choosing only one for manual movement
    public static List<DroneMovement> drones = new List<DroneMovement>();
    // drone is ready to work
    public bool isActivated = false;
    public KeyCode droneSelect;
    private DeliveryOrder currentOrder = null;
    public GameObject targetMarker;
    public TMP_Text status;
    public TMP_Text quest;

    // Start is called before the first frame update
    void Awake()
    {
        drones.Add(this);
        Debug.Log("Drone added " + ", isActivated: " + isActivated);

        leftStep = new Vector3(-movementStep, 0, 0);
        rightStep = new Vector3(movementStep, 0, 0);
        upStep = new Vector3(0, movementStep, 0);
        downStep = new Vector3(0, -movementStep, 0);
    }

    void ManualMove() {
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !isMoving)
        {
            Debug.Log("Move down " + downStep);
            StartCoroutine(MoveDrone(downStep));
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !isMoving)
        {
            Debug.Log("Move up " + upStep);
            StartCoroutine(MoveDrone(upStep));
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !isMoving)
        {
            Debug.Log("Move left " + leftStep);
            StartCoroutine(MoveDrone(leftStep));
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !isMoving)
        {
            Debug.Log("Move right " + rightStep);
            StartCoroutine(MoveDrone(rightStep));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if (Input.GetKeyDown(droneSelect))
            {
                SelectAsControlled();
            }

            if (isUnderControl)
            {
                ManualMove();
            }
        }
    }

    public void SelectAsActivated()
    {
        Debug.Log("Drone " + this.name + " is activated");
        isActivated = true;
    }

    public void SelectAsControlled()
    {
        foreach (DroneMovement obj in drones)
            obj.isUnderControl = false;
        isUnderControl = true;
        // place here code for highlighting controlled drone
    }

    private void OnMouseDown()
    {
        if (isActivated)
            SelectAsControlled();
    }

    private IEnumerator MoveDrone(Vector3 direction)
    {
        float elapsedTime = 0f;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        if (!Physics2D.OverlapCircle(targetPosition, 0.02f, noMovementLayer))
        {
            isMoving = true;


            float timeToMove = 2 / speed;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger " + collision);
        if (currentOrder is not null)
        {
            if (collision.name == currentOrder.deliverPlace)
            {
                OrdersManager.DeliverOrder(currentOrder);
                currentOrder = null;
                status.text = "No task";
                quest.text = "Find shop! Now!";
                targetMarker.transform.position = new Vector3(-100, -100, 2);
            }
        }
        else
        {
            currentOrder = OrdersManager.GetOrder(collision.name);
            if (currentOrder is not null)
            {
                Debug.Log(targetMarker + " " + currentOrder.destination);
                status.text = "Delivery";
                quest.text = "Deliver order to triangle! Now!";
                Vector3 markerNewPosition = currentOrder.destination;
                markerNewPosition.z = -2;
                targetMarker.transform.position = markerNewPosition;
            }
        }
    }
}
