using Colyseus.Schema;
using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    internal void OnChange(List<DataChange> changes)
    {
        Vector3 position = transform.position;
        foreach (DataChange dataChange in changes)
        {
            switch (dataChange.Field)
            {
                case "x":
                    position.x = (float)dataChange.Value;
                    break;
                case "y":
                    position.z = (float)dataChange.Value;
                    break;
                default:
                    Debug.LogWarning("Field change is not tracked " + dataChange.Field);
                    break;
            }
        }

        transform.position = position;
    }
}
