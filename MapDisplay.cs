using System.Collections;
using UnityEngine;

//MapDisplay Class will convert the noise map to a texture then apply that texture to a plain to draw it
public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;
    
    //This method will actually draw the map, for now
    public void DrawTexture(Texture2D texture)
    {
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
