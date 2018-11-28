
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
    }
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

function f4(shouldInitialize: boolean) {
    if (shouldInitialize) {
        var x = 10;
    }

    return x;
}

f4(true);  // returns '10'
f4(false); // returns 'undefined'

function sumMatrix(matrix: number[][]) {
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
    setTimeout(function() { console.log(i); }, 100 * i);
}

for (var i = 0; i < 10; i++) {
    // capture the current state of 'i'
    // by invoking a function with its current value
    (function(i) {
        setTimeout(function() { console.log(i); }, 100 * i);
    })(i);
}

console.log("** let declarations ***");
let hello = "Hello!";

function f(input: boolean) {
    let a = 100;

    if (input) {
        // Still okay to reference 'a'
        let b = a + 1;
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
let a1;

function foo1() {
     // okay to capture 'a'
    return a1;
}

// illegal call 'foo' before 'a' is declared
// runtimes should throw an error here
foo1();

let a;


console.log("** Re-declarations and Shadowing ***");

function f5(x) {
    var x;
    var x;

    if (true) {
        var x
    }
}

let x1 = 10;
let x2 = 20; // error: can't re-declare 'x1' in the same scope

function f6(x3) {
    let x4 = 100; // error: interferes with parameter declaration
}

function g1() {
    let x5 = 100;
    var x6 = 100; // error: can't have both declarations of 'x'
}

function f7(condition, x) {
    if (condition) {
        let x = 100;
        return x;
    }

    return x;
}

f7(false, 0); // returns '0'
f7(true, 0);  // returns '100'

function sumMatrix1(matrix: number[][]) {
    let sum = 0;
    for (let i = 0; i < matrix.length; i++) {
        var currentRow = matrix[i];
        for (let i = 0; i < currentRow.length; i++) {
            sum += currentRow[i];
        }
    }
     
    return sum;  
}

console.log("*** Block-scoped variable capturing ***");
function theCityThatAlwaysSleeps() {
    let getCity;

    if (true) {
        let city = "Seattle";
        getCity = function() {
            return city;
        }
    }
    
    return getCity();
}
theCityThatAlwaysSleeps();

for (let i = 0; i < 10 ; i++) {
    setTimeout(function() { console.log(i); }, 100 * i);
}

console.log("*** const declarations ***");

const numLivesForCat = 9;
const kitty = {
    name: "Aurora",
    numLives: numLivesForCat,
}

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

let input = [1, 2];
let [first, second] = input;
console.log("outputFirst -->"+first); // outputs 1
console.log("outputSecond -->"+second); // outputs 2

first = input[0];
second = input[1];
[first, second] = [second, first];
function f8([first, second]: [number, number]) {
    console.log("output2First -->"+first);
    console.log("output2Second -->"+second);
}
f8([1, 2]);

console.log("*** Object destructuring ***");

let o = {
    aa: "foo",
    bb: 12,
    cc: "bar"
};
let { aa, bb } = o;

({ aa, bb } = { aa: "baz", bb: 101 });

let { aa:string, ...passthrough } = o;
let total = passthrough.bb + passthrough.cc.length;

console.log("*** Default values ***");
function keepWholeObject(wholeObject: { a: string, b?: number }) {
    let { a, b = 1001 } = wholeObject;
}

console.log("*** Function declarations ***");

type C = { a: string, b?: number }
function f9({ a, b }: C): void {
    // ...
}

function f10({ a="", b=0 } = {}): void {
    // ...
}
f10();

function f11({ a, b = 0 } = { a: "" }): void {
    // ...
}
f11({ a: "yes" }); // ok, default b = 0
f11(); // ok, default to { a: "" }, which then defaults b = 0
//f11({}); // error, 'a' is required if you supply an argument

console.log("*** Spread ***");
let first1 = [1, 2];
let second1= [3, 4];
let bothPlus = [0, ...first1, ...second1, 5];

let defaults = { food: "spicy", price: "$$", ambiance: "noisy" };
let search = { ...defaults, food: "rich" };

let defaults1 = { food: "spicy", price: "$$", ambiance: "noisy" };
let search1 = { food: "rich", ...defaults };

class CC {
    p = 12;
    m() {
    }
  }
  let cc = new CC();
  let clone = { ...cc };
  clone.p; // ok
  //clone.m(); // error!

