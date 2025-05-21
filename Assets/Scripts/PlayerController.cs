using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float horizontalMove;
    [SerializeField] public float verticalMove;

    [SerializeField] public CharacterController player;

    [SerializeField] public float playerSpeed;

    [SerializeField] public float interactionDistance = 3f;

    [SerializeField] public KeyCode interactKey = KeyCode.E; 


    void Start()
    {
        player = GetComponent<CharacterController>();   
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(interactKey))
        {
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
    }

    void TryInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractuable interactuable = hit.collider.GetComponent<IInteractuable>();

            if (interactuable != null)
            {
                interactuable.Interact();
            }
        }
    }
}
