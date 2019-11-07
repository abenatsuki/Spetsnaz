using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField,Tooltip("ギズモの大きさ")]
     float gizmoSize = .75f;
    [SerializeField,Tooltip("ギズモの色")]
     Color gizmoColor = Color.yellow;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
    
}
