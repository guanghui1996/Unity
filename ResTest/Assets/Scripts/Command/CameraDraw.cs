using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDraw : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, new Vector3(-12, 10, 20) * 10);
        Gizmos.DrawLine(transform.position, new Vector3(12, 10, 20) * 10);
        Gizmos.DrawLine(transform.position, new Vector3(-12, -10, 20) * 10);
        Gizmos.DrawLine(transform.position, new Vector3(12, -10, 20) * 10);
    }
}
