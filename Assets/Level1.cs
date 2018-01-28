using UnityEngine;

public class SpawnPoint {
	public Vector2 position;
	public int unitsToSpawn;
  
  public SpawnPoint(Vector2 _position, int _unitsToSpawn) {
    position = _position;
    unitsToSpawn = _unitsToSpawn;
  }
  
  public void unitSpawned() {
    unitsToSpawn--;
  }
}

public class Level1 {
static public TileTypes[,] tilemap = new TileTypes[,] {
   {TileTypes.DeepB_90, TileTypes.DeepB_0, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Water, TileTypes.Background} ,
 {TileTypes.DeepB_180, TileTypes.DeepB_270, TileTypes.Background, TileTypes.Water, TileTypes.Background, TileTypes.Water, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Water, TileTypes.Background, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Water, TileTypes.Water, TileTypes.Water, TileTypes.Thorntendrils, TileTypes.Water, TileTypes.Water} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Stonewall, TileTypes.Background, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Stonewall, TileTypes.Stonewall, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Stonewall, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background, TileTypes.DeepC_270, TileTypes.Water} ,
 {TileTypes.Background, TileTypes.Water, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.DeepC_180, TileTypes.DeepA_90, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background, TileTypes.DeepC_90, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Background} ,
 {TileTypes.Background, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Thorntendrils, TileTypes.Background, TileTypes.Thorntendrils} ,
 {TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Background, TileTypes.Thorntendrils} 
};

static public SpawnPoint[] catSpawnPoints = new SpawnPoint[] {new SpawnPoint(new Vector2(1, -6), 2)};
static public SpawnPoint[] turtleSpawnPoints = new SpawnPoint[] {new SpawnPoint(new Vector2(12, -6), 2)};
static public SpawnPoint[] birdSpawnPoints = new SpawnPoint[] {new SpawnPoint(new Vector2(8, 0), 3)};
}

