using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour
{
    public Material mat;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //src is the fully rendered scene that you'd send directly to the monitor
        //we intercept this so we can work it before it gets passed on
        Graphics.Blit(source, destination, mat);


    }
}
