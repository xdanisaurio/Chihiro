using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractuable
{
    [SerializeField] private bool isOpen = false;

    [SerializeField] private Quaternion closedRotation;
    [SerializeField] private Quaternion openRotation;

    [SerializeField] public float openAngle = 90f;
    [SerializeField] public float openSpeed = 2f;  

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, transform.eulerAngles.y + openAngle, 0);
    }

    public void Interact()
    {
        isOpen = !isOpen;
        StopAllCoroutines();
        StartCoroutine(RotateDoor(isOpen ? openRotation : closedRotation));
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }
        transform.rotation = targetRotation; 
    }
}