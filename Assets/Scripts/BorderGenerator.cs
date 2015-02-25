using UnityEngine;
using System.Collections;

public class BorderGenerator : MonoBehaviour {

    public Sprite borderTile;

    private enum Direction
    {
        vertical,
        horizontal
    };

    private GameObject borderContainer;

	// Use this for initialization
	void Start () {
        generateWalls();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void generateWalls() {
        if (borderContainer == null)
        {
            borderContainer = new GameObject();
            
            borderContainer.transform.position = Vector3.zero;
        }
        generateWall(25, new Vector2(0,0), Direction.vertical);
        generateWall(25, new Vector2(16,0), Direction.horizontal);
    }

    private void generateWall(int number, Vector2 startLoc, Direction dir) {
        for ( int i = 0; i < number; i ++ ) {
            Sprite borderTile = new Sprite();
            GameObject borderTileGO = new GameObject();
            borderTileGO.transform.position = Vector3.zero;
            borderTileGO.transform.parent = borderContainer.transform;
            if (dir == Direction.horizontal) {
                borderTileGO.transform.localPosition = new Vector2(startLoc.x + i, startLoc.y);
            } else if ( dir == Direction.vertical) {
                borderTileGO.transform.localPosition = new Vector2(startLoc.x, startLoc.y + i);
            }
            SpriteRenderer borderTileSpriteRenderer = new SpriteRenderer();
            borderTileSpriteRenderer.sprite = borderTile;
            SpriteRenderer borderTileGOSpriteRenderer = borderTileGO.AddComponent<SpriteRenderer>();
//            borderTileGO = borderTileGOSpriteRenderer;
        }
    }


}
