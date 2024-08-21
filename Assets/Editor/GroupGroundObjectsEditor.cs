using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class GroupGroundObjectsEditor : EditorWindow
{
    [MenuItem("Tools/Group Ground Objects")]
    public static void GroupGroundObjects()
    {
        // Find or create the "Ground" folder in the hierarchy
        GameObject groundFolder = GameObject.Find("Ground");
        if (groundFolder == null)
        {
            groundFolder = new GameObject("Ground");
        }

        // Iterate through all objects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the object's name contains any of the specified keywords
            if (obj.name.Contains("Road") || obj.name.Contains("Sidewalk") ||
                obj.name.Contains("Stairs") || obj.name.Contains("Grass"))
            {
                // Move the object to the "Ground" folder
                obj.transform.parent = groundFolder.transform;
            }
        }

        UnityEngine.Debug.Log("Ground objects have been moved successfully!");
    }
}

