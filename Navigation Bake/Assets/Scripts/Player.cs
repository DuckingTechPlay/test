using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private void Update()
    {
        // Detecta si se ha presionado el botón izquierdo del ratón
        if (Input.GetButtonDown("Fire1"))
        {
            // Crea un rayo desde la cámara principal hacia la posición del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            // Realiza un raycast y verifica si ha golpeado algo
            if (Physics.Raycast(ray, out hit, 1000))
            {
                // Establece el destino del agente de navegación al punto donde golpeó el rayo
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
    }
}
