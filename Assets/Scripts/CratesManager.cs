using UnityEngine;

public class CratesManager : MonoBehaviour
{
    CheckCollisionNumber[] allCrates;

    void Start()
    {
        allCrates = FindObjectsByType<CheckCollisionNumber>(FindObjectsSortMode.None);
    }

    void Update()
    {
        if (AreAllCratesFilled())
        {
            Debug.Log("Victoire : toutes les caisses sont remplies avec les bonnes pommes !");
            enabled = false; 
        }
    }

    bool AreAllCratesFilled()
    {
        foreach (CheckCollisionNumber crate in allCrates)
        {
            if (!crate.IsCompleted())
            {
                return false;
            }
        }

        return true;
    }
}