using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        // Garante que a animação não bloqueia a deslocação física do NavMeshAgent
        if (anim != null)
        {
            anim.applyRootMotion = false;
        }

        // Verifica os checkpoints recolhidos pelo singleton
        Debug.Log("Checkpoints encontrados: " + GameEnvironment.Singleton.Checkpoints.Count);

        // Inicia logo em modo de patrulha para validar o movimento imediatamente
        currentState = new Patrol(this.gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState = currentState.Process();
        }
    }
}