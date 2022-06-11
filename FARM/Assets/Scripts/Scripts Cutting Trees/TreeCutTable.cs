using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutTable : ToolHit
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
