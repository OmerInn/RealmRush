using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("name:" + this.name+size);
        Scale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Scale()
    {
        this.transform.Translate(new Vector3( 10f, 0,0));
    }
}
