// const {} from 'lodash'

const number2Enum = {
  0: "TileTypes.DeepC_180",
  1: "TileTypes.DeepB_90",
  2: "TileTypes.DeepB_180",
  3: "TileTypes.Stonewall",
  4: "TileTypes.Water",
  5: "TileTypes.DeepA",
  6: "TileTypes.DeepB_0",
  7: "TileTypes.DeepB_270",
  8: "TileTypes.Thorntendrils",
  9: "TileTypes.Background",
  10: "TileTypes.DeepC_0"
};

const tiledmap = require("../Assets/TilemapJSON.json");

const map = [];

for (var y = 0; y < tiledmap.height; y++) {
  map.push(tiledmap.layers[0].data.splice(0, tiledmap.width));
}

process._rawDebug(
  "map",
  require("util").inspect(map, { depth: null, colors: true }),
  "\n"
);

console.log(`
TileTypes[,] tilemap = new TileTypes[,] {
  ${map
    .map(line => ` {${line.map(tile => number2Enum[tile]).join(", ")}} `)
    .join(",\n")}
};
`);
