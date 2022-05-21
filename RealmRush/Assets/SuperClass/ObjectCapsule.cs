using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCapsule: ObjectBase
{
    public override void Scale()
    {
        base.Scale();
        this.transform.Translate(new Vector3(0,10f, 0));
    }
}
