using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("State Machine Debug", EditorStyles.boldLabel);

        PlayerController player = (PlayerController)target;

        if (Application.isPlaying && player.PlayerStateMachine != null)
        {
            var currentState = player.PlayerStateMachine.CurrentState;
            string stateName = currentState?.GetType().Name ?? "Nenhum";

            GUI.color = Color.cyan;
            EditorGUILayout.LabelField("Estado Atual:", stateName, EditorStyles.boldLabel);
            GUI.color = Color.white;

            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Forçar Transição Manual:", EditorStyles.miniLabel);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("→ Locomotion (Chão)"))
            {
                player.PlayerStateMachine.TransitionTo(player.LocomotionState);
            }

            if (GUILayout.Button("→ Jump (Ar)"))
            {
                player.PlayerStateMachine.TransitionTo(player.JumpState);
            }

            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.HelpBox("Entre no Play Mode para inspecionar e forçar estados em tempo real.", MessageType.Info);
        }
    }
}
