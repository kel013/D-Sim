using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    KeyCode interactKey = KeyCode.E;
    [SerializeField]
    float range = 5;
    [SerializeField]
    LayerMask layer;

    public AudioClip grabSound;

    private void Update()
    {
        if(Input.GetKeyDown(interactKey))
        {
            interact();
        }
    }
    public void interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,out hit,range,layer))
        {
            Debug.Log("hit " + hit.transform.gameObject.name);
            Interactable obj = hit.transform.gameObject.GetComponent<Interactable>();
            if (obj != null)
            {
                obj.Interact();
            }
        }
    }
}
