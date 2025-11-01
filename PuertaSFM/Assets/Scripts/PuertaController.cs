using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    [SerializeField] GameObject puertaIzq;
    [SerializeField] GameObject puertaDer;
    public enum PuertaState { OPEN, OPENING, CLOSED, CLOSENING }
    PuertaState state = PuertaState.CLOSED;

    private void Update()
    {
        switch (state)
        {
            case PuertaState.OPEN:
                break;
            case PuertaState.OPENING:
                break;
            case PuertaState.CLOSED:
                break;
            case PuertaState.CLOSENING:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            state = PuertaState.OPENING;
        }
    }
}
