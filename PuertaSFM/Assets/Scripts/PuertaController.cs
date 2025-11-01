using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class PuertaController : MonoBehaviour
{
    [SerializeField] GameObject puertaIzq;
    [SerializeField] GameObject puertaDer;
    public enum PuertaState { OPEN, OPENING, CLOSED, CLOSENING }
    PuertaState state = PuertaState.CLOSED;
    public Vector3 rotationPuerta = new Vector3(0, 0, 1);
    private void Update()
    {
        UpdateState();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")== true)
        {
            Invoke("openingDoor", 2f);
        }
    }
    private void openingDoor()
    {
        Debug.Log("Abriendo puerta");
        puertaIzq.transform.rotation = Quaternion.AngleAxis(45, rotationPuerta);
        puertaDer.transform.rotation = Quaternion.AngleAxis(-45, rotationPuerta);
        state = PuertaState.OPEN;
        
    }
    private void puertaAbierta()
    {
        puertaIzq.transform.rotation = Quaternion.AngleAxis(90, rotationPuerta);
        puertaDer.transform.rotation = Quaternion.AngleAxis(-90, rotationPuerta);
        Debug.Log("Puerta abierta");
        state = PuertaState.CLOSENING;
        
    }
    private void closeningDoor()
    {
        puertaIzq.transform.rotation = Quaternion.AngleAxis(45, rotationPuerta);
        puertaDer.transform.rotation = Quaternion.AngleAxis(-45, rotationPuerta);
        Debug.Log("Puerta cerrandose");
        state = PuertaState.CLOSED;
    }
    private void puertaCerrada()
    {
        puertaIzq.transform.rotation = Quaternion.AngleAxis(0, rotationPuerta);
        puertaDer.transform.rotation = Quaternion.AngleAxis(0, rotationPuerta);
        Debug.Log("Puerta cerrada");
        state = PuertaState.OPEN;
    }
    private void UpdateState()
    {
        switch (state)
        {
            case PuertaState.OPEN:
                Invoke("puertaAbierta", 2f);
                break;
            case PuertaState.OPENING:
                break;
            case PuertaState.CLOSED:
                break;
            case PuertaState.CLOSENING:
                Invoke("closeningDoor", 4f);
                break;
        }
    }
}
