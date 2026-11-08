using UnityEngine;
using System.Collections.Generic;

public class CheckCollisionNumber : MonoBehaviour
{
    [SerializeField] AppleType targetType;
    public int appleNumber;
    List<GameObject> currentCollisions = new();

    void OnCollisionStay(Collision col)
    {
        Apple apple = col.gameObject.GetComponent<Apple>();
        // Debug.Log("stay " + apple.type);

        if (apple != null && apple.type == targetType && !currentCollisions.Contains(col.gameObject))
        {
            currentCollisions.Add(col.gameObject);
            CheckApples();
        }
    }

    void OnCollisionExit(Collision col)
    {
        Apple apple = col.gameObject.GetComponent<Apple>();
        // Debug.Log("sort " + apple.type);

        if (apple != null && apple.type == targetType && currentCollisions.Contains(col.gameObject))
        {
            currentCollisions.Remove(col.gameObject);
            CheckApples();
        }
    }

    void CheckApples()
    {
        int matchingCount = currentCollisions.Count;
        Debug.Log("Pommes valides dans cette caisse : " + matchingCount + " / " + appleNumber);
    }

    public bool IsCompleted()
    {
        return currentCollisions.Count == appleNumber;
    }
}