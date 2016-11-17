using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

public class IsHasFlag : Conditional {

    private Offense offense;

    public override void OnAwake()
    {

        offense = this.GetComponent<Offense>();
        Debug.Log("hell");
    }

    public override TaskStatus OnUpdate()
    {

        if (offense.hasFlag)
        {
            return TaskStatus.Success;
           // Debug.Log("hell");
        }
        return TaskStatus.Failure;
        //Debug.Log("hellddd");
    }

}
