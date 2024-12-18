# Navigation AI Demo

¡Bienvenido a la demostración de Navigation AI en Unity! Este proyecto es una simple implementación de inteligencia artificial de navegación para mostrar cómo los agentes pueden moverse en un entorno 3D.

## Características
- Implementación básica de AI de navegación.
- Agentes que buscan y siguen caminos en tiempo real.
- Fácil de entender y modificar para tus propios proyectos.

## Requisitos
- Unity 2022.3 o superior.

## Instalación
1. Clona este repositorio en tu máquina local.
    ```sh
    git clone https://github.com/DuckingTechPlay/test/tree/master
    ```
2. Abre el proyecto en Unity.
3. Ejecuta la escena principal para ver la AI en acción.

## Uso
- Los agentes están programados para moverse hacia objetivos predefinidos.
- Puedes agregar más agentes y objetivos en la escena para observar su comportamiento.

## Primer Commit
- subido unicamente el proyecto sin modificacion

## Segundo Commit
- subido un script de prueba, movimiento por puntos de patrulla.
  
  using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Capa que define el suelo en el que el jugador puede caminar
    public LayerMask LayerFloor;

    // Transform que contiene la ruta de puntos de patrulla
    public Transform routeFather;

    // Índice del hijo actual en la ruta
    int indexChildren;

    // Destino actual del agente de navegación
    Vector3 destination;

    // Vectores que delimitan la zona de patrulla
    public Vector3 min, max;

    private void Start()
    {
        // Establece el primer destino como una posición aleatoria dentro de los límites definidos
        destination = RandomDestination();

        // Establece el destino del agente de navegación al primer destino
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    private void Update()
    {
        #region movimiento por click
        // Detecta si se ha presionado el botón izquierdo del ratón
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     // Crea un rayo desde la cámara principal hacia la posición del ratón
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit = new RaycastHit();
        //
        //     // Realiza un raycast y verifica si ha golpeado algo
        //     if (Physics.Raycast(ray, out hit, 1000, LayerFloor))
        //     {
        //         // Establece el destino del agente de navegación al punto donde golpeó el rayo
        //         GetComponent<NavMeshAgent>().SetDestination(hit.point);
        //     }
        // }
        #endregion

        #region Movimiento por puntos
        // Verifica si el agente ha llegado cerca del destino actual
        if (Vector3.Distance(transform.position, destination) < 1.1)
        {
            // Selecciona un índice de hijo aleatorio para moverse al siguiente punto de patrulla
            indexChildren = Random.Range(0, routeFather.childCount);

            // Si el índice supera el número de hijos, reinícialo a 0 para empezar de nuevo
            if (indexChildren >= routeFather.childCount)
                indexChildren = 0;

            // Establece el nuevo destino como la posición del siguiente hijo
            destination = routeFather.GetChild(indexChildren).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
        #endregion

        // Verifica si el agente ha llegado cerca del destino actual dentro del área delimitada
        if (Vector3.Distance(transform.position, destination) < 1.1)
        {
            // Establece un nuevo destino aleatorio dentro de los límites definidos
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

    // Método para generar un destino aleatorio dentro de un área delimitada
    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}

## Tercer Commit
Imagen de prueba

!(Navigation Bake/Assets/Iluminados_1.jpg)

