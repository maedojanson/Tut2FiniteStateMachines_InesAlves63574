using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints 
    { 
        get 
        { 
            // Se por algum motivo a lista estiver vazia, recarrega imediatamente da cena
            if (checkpoints.Count == 0)
            {
                checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return checkpoints; 
        } 
    }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }
}