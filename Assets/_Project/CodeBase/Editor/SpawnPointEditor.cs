using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPoint))]
public class SpawnPointEditor : UnityEditor.Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(SpawnPoint spawner, GizmoType gizmo)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(spawner.transform.position, 0.4f);
    }
}