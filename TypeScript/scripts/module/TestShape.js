"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var circle = require("./Circle");
var triangle = require("./Triangle");
function drawAllShapes(shapeToDraw) {
    shapeToDraw.draw();
}
drawAllShapes(new circle.Circle());
drawAllShapes(new triangle.Triangle());
// When defining external module in TypeScript targeting CommonJS or AMD, each file is considered as a module. So it’s optional to use internal module with in external module.
// NOTE: compile this way
// compile options
// 1. "amd": "Asynchronous Module Definition" -- this is for web
// 2. "commonjs" -- this is for node (server side)
// tsc --module amd TestShape.ts
// tsc --module commonjs TestShape.ts
