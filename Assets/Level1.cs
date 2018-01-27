using UnityEngine;

public class Level1 {
static public TileTypes[,] tilemap = new TileTypes[,] {
        {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background},
        {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background},
        {TileTypes.Water, TileTypes.Water, TileTypes.Water, TileTypes.Water, TileTypes.Water, TileTypes.Water},
        {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background},
        {TileTypes.Background, TileTypes.Background, TileTypes.DeepC_270, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background},
        {TileTypes.Background, TileTypes.Background, TileTypes.DeepC_90, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background},
        {TileTypes.Stonewall, TileTypes.Stonewall, TileTypes.Stonewall, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Thorntendrils},
        {TileTypes.Background, TileTypes.Background, TileTypes.Stonewall, TileTypes.Background, TileTypes.Background, TileTypes.Background},
        {TileTypes.Background, TileTypes.Background, TileTypes.Stonewall, TileTypes.DeepC_180, TileTypes.DeepA_0, TileTypes.DeepC_0},
        {TileTypes.Background, TileTypes.Background, TileTypes.Stonewall, TileTypes.Background, TileTypes.Background, TileTypes.Background}
};

static public Vector2 CatSpawnPoint = new Vector2(7, -5);
static public Vector2 BirdSpawnPoint = new Vector2(8, 0);
static public Vector2 TurtleSpawnPoint = new Vector2(0, 0);
}

