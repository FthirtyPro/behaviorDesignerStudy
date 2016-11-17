using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class defense : Action {


    public SharedFloat viewDistance;
    public SharedFloat fieldOfViewAngle;
    public SharedFloat speed;
    public SharedFloat angularSpeed;
    public SharedTransform target;

    private NavMeshAgent navMeshAgent;
    private float sqrViewDistance;

    public override void OnAwake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 

    }
    public override void OnStart()
    {
        sqrViewDistance = viewDistance.Value * viewDistance.Value;
        navMeshAgent.enabled = true;
        navMeshAgent.destination = target.Value.position;
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value;
    }

    public override void OnEnd()
    {
        navMeshAgent.enabled = false;
    }

    public override  TaskStatus OnUpdate()
    {
        if(target ==null&& target.Value ==null)
        {
            Debug.Log("llll");
            return TaskStatus.Failure;
        }
        float sqrDistance =(target.Value.position - transform.position).sqrMagnitude;
        float angle = Vector3.Angle(transform.forward, target.Value.position - transform.position);
        if(sqrDistance< sqrViewDistance && angle< fieldOfViewAngle.Value*0.5)
        {
            if(navMeshAgent.destination != target.Value.position)
                {
                navMeshAgent.destination = target.Value.position; 
            }

            return TaskStatus.Running;
        }
        else
        {

            return TaskStatus.Success;

        }



    }


}
