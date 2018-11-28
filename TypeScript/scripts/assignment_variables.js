var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var __rest = (this && this.__rest) || function (s, e) {
    var t = {};
    for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
        t[p] = s[p];
    if (s != null && typeof Object.getOwnPropertySymbols === "function")
        for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) if (e.indexOf(p[i]) < 0)
            t[p[i]] = s[p[i]];
    return t;
};
var _a, _b;
console.log("** var declarations ***");
function f1() {
    var message = "Hello, world!";
    return message;
}
function f2() {
    var a = 10;
    return function g() {
        var b = a + 1;
        return b;
    };
}
var g = f2();
g(); // returns '11'
function f3() {
    var a = 1;
    a = 2;
    var b = g();
    a = 3;
    return b;
    function g() {
        return a;
    }
}
f3(); // returns '2'
console.log("** Scoping rules ***");
function f4(shouldInitialize) {
    if (shouldInitialize) {
        var x = 10;
    }
    return x;
}
f4(true); // returns '10'
f4(false); // returns 'undefined'
function sumMatrix(matrix) {
    var sum = 0;
    for (var i = 0; i < matrix.length; i++) {
        var currentRow = matrix[i];
        for (var i = 0; i < currentRow.length; i++) {
            sum += currentRow[i];
        }
    }
    return sum;
}
console.log("** Variable capturing quirks***");
for (var i = 0; i < 10; i++) {
    setTimeout(function () { console.log(i); }, 100 * i);
}
for (var i = 0; i < 10; i++) {
    // capture the current state of 'i'
    // by invoking a function with its current value
    (function (i) {
        setTimeout(function () { console.log(i); }, 100 * i);
    })(i);
}
console.log("** let declarations ***");
var hello = "Hello!";
function f(input) {
    var a = 100;
    if (input) {
        // Still okay to reference 'a'
        var b = a + 1;
        return b;
    }
    // Error: 'b' doesn't exist here
    // return b;
}
try {
    throw "oh no!";
}
catch (e) {
    console.log("Oh well.");
}
// Error: 'e' doesn't exist here
//console.log(e);
//a++; // illegal to use 'a' before it's declared;
var a1;
function foo1() {
    // okay to capture 'a'
    return a1;
}
// illegal call 'foo' before 'a' is declared
// runtimes should throw an error here
foo1();
var a;
console.log("** Re-declarations and Shadowing ***");
function f5(x) {
    var x;
    var x;
    if (true) {
        var x;
    }
}
var x1 = 10;
var x2 = 20; // error: can't re-declare 'x1' in the same scope
function f6(x3) {
    var x4 = 100; // error: interferes with parameter declaration
}
function g1() {
    var x5 = 100;
    var x6 = 100; // error: can't have both declarations of 'x'
}
function f7(condition, x) {
    if (condition) {
        var x_1 = 100;
        return x_1;
    }
    return x;
}
f7(false, 0); // returns '0'
f7(true, 0); // returns '100'
function sumMatrix1(matrix) {
    var sum = 0;
    for (var i_1 = 0; i_1 < matrix.length; i_1++) {
        var currentRow = matrix[i_1];
        for (var i_2 = 0; i_2 < currentRow.length; i_2++) {
            sum += currentRow[i_2];
        }
    }
    return sum;
}
console.log("*** Block-scoped variable capturing ***");
function theCityThatAlwaysSleeps() {
    var getCity;
    if (true) {
        var city_1 = "Seattle";
        getCity = function () {
            return city_1;
        };
    }
    return getCity();
}
theCityThatAlwaysSleeps();
var _loop_1 = function (i_3) {
    setTimeout(function () { console.log(i_3); }, 100 * i_3);
};
for (var i_3 = 0; i_3 < 10; i_3++) {
    _loop_1(i_3);
}
console.log("*** const declarations ***");
var numLivesForCat = 9;
var kitty = {
    name: "Aurora",
    numLives: numLivesForCat,
};
// Error
//kitty1 = {
//    name: "Danielle",
//    numLives: numLivesForCat
//};
// all "okay"
kitty.name = "Rory";
kitty.name = "Kitty";
kitty.name = "Cat";
kitty.numLives--;
console.log("*** Array destructuring ***");
var input = [1, 2];
var first = input[0], second = input[1];
console.log("outputFirst -->" + first); // outputs 1
console.log("outputSecond -->" + second); // outputs 2
first = input[0];
second = input[1];
_a = [second, first], first = _a[0], second = _a[1];
function f8(_a) {
    var first = _a[0], second = _a[1];
    console.log("output2First -->" + first);
    console.log("output2Second -->" + second);
}
f8([1, 2]);
console.log("*** Object destructuring ***");
var o = {
    aa: "foo",
    bb: 12,
    cc: "bar"
};
var aa = o.aa, bb = o.bb;
(_b = { aa: "baz", bb: 101 }, aa = _b.aa, bb = _b.bb);
var string = o.aa, passthrough = __rest(o, ["aa"]);
var total = passthrough.bb + passthrough.cc.length;
console.log("*** Default values ***");
function keepWholeObject(wholeObject) {
    var a = wholeObject.a, _a = wholeObject.b, b = _a === void 0 ? 1001 : _a;
}
console.log("*** Function declarations ***");
function f9(_a) {
    var a = _a.a, b = _a.b;
    // ...
}
function f10(_a) {
    var _b = _a === void 0 ? {} : _a, _c = _b.a, a = _c === void 0 ? "" : _c, _d = _b.b, b = _d === void 0 ? 0 : _d;
    // ...
}
f10();
function f11(_a) {
    var _b = _a === void 0 ? { a: "" } : _a, a = _b.a, _c = _b.b, b = _c === void 0 ? 0 : _c;
    // ...
}
f11({ a: "yes" }); // ok, default b = 0
f11(); // ok, default to { a: "" }, which then defaults b = 0
//f11({}); // error, 'a' is required if you supply an argument
console.log("*** Spread ***");
var first1 = [1, 2];
var second1 = [3, 4];
var bothPlus = [0].concat(first1, second1, [5]);
var defaults = { food: "spicy", price: "$$", ambiance: "noisy" };
var search = __assign({}, defaults, { food: "rich" });
var defaults1 = { food: "spicy", price: "$$", ambiance: "noisy" };
var search1 = __assign({ food: "rich" }, defaults);
var CC = /** @class */ (function () {
    function CC() {
        this.p = 12;
    }
    CC.prototype.m = function () {
    };
    return CC;
}());
var cc = new CC();
var clone = __assign({}, cc);
clone.p; // ok
//clone.m(); // error!
//# sourceMappingURL=assignment_variables.js.map