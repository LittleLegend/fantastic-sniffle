// const {} from 'lodash'

const number2Enum = {
  1: "TileTypes.DeepC_180",
  2: "TileTypes.DeepB_90",
  3: "TileTypes.DeepB_180",
  4: "TileTypes.Stonewall",
  5: "TileTypes.Water",
  6: "TileTypes.DeepA",
  7: "TileTypes.DeepB_0",
  8: "TileTypes.DeepB_270",
  9: "TileTypes.Thorntendrils",
  10: "TileTypes.Background",
  11: "TileTypes.DeepC_0"
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
