const { cloneDeep } = require("lodash");

const number2Enum = {
  1: "TileTypes.DeepC_180",
  2: "TileTypes.DeepB_90",
  3: "TileTypes.DeepB_180",
  4: "TileTypes.Stonewall",
  5: "TileTypes.Water",
  6: "TileTypes.DeepA_0",
  7: "TileTypes.DeepB_0",
  8: "TileTypes.DeepB_270",
  9: "TileTypes.Thorntendrils",
  10: "TileTypes.Background",
  11: "TileTypes.DeepC_0",
  12: "TileTypes.DeepC_270",
  13: "TileTypes.DeepA_90",
  14: "TileTypes.DeepC_90",
  15: "TileTypes.DeepS"
};

const tiledmap = require("../Assets/Level1.json");

const map = [];

for (var y = 0; y < tiledmap.height; y++) {
  map.push(tiledmap.layers[0].data.splice(0, tiledmap.width));
}

const mapRotate = [];

map.forEach((line, x) => {
  line.forEach((tile, y) => {
    if (!mapRotate[y]) {
      mapRotate[y] = [];
    }

    mapRotate[y][x] = tile;
  });
});

process._rawDebug(
  "map",
  require("util").inspect(map, {
    depth: null,
    colors: true
  }),
  "\n"
);

process._rawDebug(
  "mapRotate",
  require("util").inspect(mapRotate, {
    depth: null,
    colors: true
  }),
  "\n"
);

let catSpawnPoint;
let birdSpawnPoint;
let turtleSpawnPoint;

tiledmap.layers[1].objects.forEach(o => {
  if (o.name === "Bird") {
    birdSpawnPoint = o;
  } else if (o.name === "Cat") {
    catSpawnPoint = o;
  } else if (o.name === "Turtle") {
    turtleSpawnPoint = o;
  }
});

console.log(`using UnityEngine;

public class SpawnPoint {
	public Vector2 position;
	public int unitsToSpawn;
  resetter = _unitsToSpawn;
  
  public SpawnPoint(Vector2 _position, int _unitsToSpawn) {
    position = _position;
    unitsToSpawn = _unitsToSpawn;
  }
  
  public void unitSpawned() {
    unitsToSpawn--;
  }
	
	public void reset() {
		unitsToSpawn = resetter;
	}
}

public class Level1 {
static public TileTypes[,] tilemap = new TileTypes[,] {
  ${mapRotate
    .map(column => ` {${column.map(tile => number2Enum[tile]).join(", ")}} `)
    .join(",\n")}
};

static public SpawnPoint[] catSpawnPoints = new SpawnPoint[] {${toStruct(
  catSpawnPoint
)}};
static public SpawnPoint[] turtleSpawnPoints = new SpawnPoint[] {${toStruct(
  turtleSpawnPoint
)}};
static public SpawnPoint[] birdSpawnPoints = new SpawnPoint[] {${toStruct(
  birdSpawnPoint
)}};

static public void reset() {
	foreach(var sp in catSpawnPoints) {
		sp.reset();
	}
	foreach(var sp in turtleSpawnPoints) {
		sp.reset();
	}
	foreach(var sp in birdSpawnPoints) {
		sp.reset();
	}
}
}
`);

function toStruct(sp) {
  return `new SpawnPoint(new Vector2(${Math.round(sp.x / 128)}, ${-1 *
    Math.round(sp.y / 128)}), ${sp.properties.unitsToSpawn})`;
}
