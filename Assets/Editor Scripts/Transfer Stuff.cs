using UnityEditor;
using UnityEngine;
using System.Reflection;
//PURE GPT MALARKY I UNDERSTAND IT ENOUGH TO EDIT BUT NOT ENOUGH TO CREATE MYSELF
public static class EnemyStatsMigration
{
    [MenuItem("Tools/Migrate EnemyStats To Stats")]
    public static void Migrate()
    {
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");
        int modifiedCount = 0;

        foreach (string guid in prefabGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            bool prefabModified = false;

            foreach (var component in instance.GetComponentsInChildren<MonoBehaviour>(true))
            {
                if (component == null) continue;

                SerializedObject so = new SerializedObject(component);

                SerializedProperty enemyStatsProp = so.FindProperty("enemyStats");
                SerializedProperty statsProp = so.FindProperty("stats");

                if (enemyStatsProp != null && statsProp != null)
                {
                    // Example field mapping
                    CopyFloat(enemyStatsProp, "MaxHealth", statsProp, "MaxHealth");
                    CopyFloat(enemyStatsProp, "HPRegen", statsProp, "HPRegen");
                    CopyFloat(enemyStatsProp, "Precision", statsProp, "Precision");
                    CopyFloat(enemyStatsProp, "Power", statsProp, "Power");
                    CopyFloat(enemyStatsProp, "Evasion", statsProp, "Evasion");
                    CopyFloat(enemyStatsProp, "Command", statsProp, "Command");
                    CopyFloat(enemyStatsProp, "Luck", statsProp, "Luck");
                    CopyFloat(enemyStatsProp, "Protection", statsProp, "Protection");
                    CopyFloat(enemyStatsProp, "BruteProtection", statsProp, "BruteProtection");
                    CopyFloat(enemyStatsProp, "BurnProtection", statsProp, "BurnProtection");



                    // Optional: clear old values
                    //  enemyStatsProp.FindPropertyRelative("health").floatValue = 0f;
                    // enemyStatsProp.FindPropertyRelative("damage").floatValue = 0f;
                    // enemyStatsProp.FindPropertyRelative("speed").floatValue = 0f;


                    so.ApplyModifiedProperties();
                    prefabModified = true;
                }
            }

            if (prefabModified)
            {
                PrefabUtility.SaveAsPrefabAsset(instance, path);
                modifiedCount++;
            }

            Object.DestroyImmediate(instance);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"EnemyStats → Stats migration complete. Modified {modifiedCount} prefabs.");
    }

    private static void CopyFloat(
        SerializedProperty source,
        string sourceField,
        SerializedProperty destination,
        string destinationField)
    {
        SerializedProperty src = source.FindPropertyRelative(sourceField);
        SerializedProperty dst = destination.FindPropertyRelative(destinationField);

        if (src != null && dst != null)
        {
            dst.floatValue = src.floatValue;
        }
    }
}