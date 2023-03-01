using UnityEngine;

public class SetInvisibleLayer : MonoBehaviour
{
    LayerMask invisible_layer_mask;
    void Start()
    {
        invisible_layer_mask=LayerMask.NameToLayer("Invisible");
        invisible_layer_mask=~invisible_layer_mask;//This inverts the value
        Camera.main.cullingMask= 1<<invisible_layer_mask;
    }
}
