using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openHeight = 5.0f;
    public float openSpeed = 0.1f;
    private float direction = 0.0f;
    private float openPercent = 0.0f;
    private Vector3 closedPosition;
    private Vector3 openPosition;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != 0)
        {
            Debug.Log("We're moving!");
            openPercent += Time.deltaTime * openSpeed * direction;
            transform.position = Vector3.Lerp(closedPosition, openPosition, openPercent);
            if (openPercent >= 1.0f || openPercent <= 0.0f)
            {
                direction = 0;
            }
        }
        HandleInteraction();
    }

    void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("isOpening?");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (openPercent <= 0.0f)
                    {
                        direction = 1;
                    } else
                    {
                        direction = -1;
                    }
                }
            }
        }
    }
}
