using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("minha velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade Total", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calcule a velocidade Total do Carro", MessageType.Info);

        if(myTarget.TotalSpeed >= 200)
        {
            EditorGUILayout.HelpBox("Velocidade acima do permitido", MessageType.Error);
        }

        GUI.color = Color.blue;

        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }

    }
}
