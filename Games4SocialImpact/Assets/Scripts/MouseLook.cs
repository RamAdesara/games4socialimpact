using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    public LayerMask pickable;
    public float shootRange = 10f;

    public Transform hand;
    GameObject pickedObject;
    bool isPicked = false;

    public LayerMask collectible;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        // This means we are rotating the camera on the x axis, remember right hand rule
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("Fire1"))
        {
            if (isPicked) {
                Drop();
            } else {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, shootRange))
        {
            pickedObject = hit.transform.gameObject;
            // If pickedObject is not null and it is pickable
            if ( (pickedObject != null) && (((1 << pickedObject.layer) & pickable) != 0) )
            {
                // Pick it up
                isPicked = true;
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;

                pickedObject.transform.SetParent(hand);
                pickedObject.transform.localPosition = Vector3.zero;
                pickedObject.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void Drop()
    {
        isPicked = false;

        if (pickedObject != null)
        {
            pickedObject.transform.SetParent(null);
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
