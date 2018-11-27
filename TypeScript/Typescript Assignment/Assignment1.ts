// You can create "assignment" folder on your typescript project
// Unless the folder is excluded in "tsconfig.json", once you command "tsc", it will transcomplie all your ts files
// and it will generate relevant js files under "scripts" folder as we did it in classroom.


console.log("===== Typescript Assignment 1 =====\n\n");

// 1. This is about "Different ways of creating an Object in javascript" (not TypeScript)
// refer to https://coderwall.com/p/p5cf5w/different-ways-of-creating-an-object-in-javascript      this site has some errors
// copy and paste is allowed
// you can create your own js file such as differentWaysToObject.js


console.log("===== Q1. Different ways of creating an Object in javascript =====\n");

// 1. Using the Object() constructor:
var obj0 = new Object();
// This is the simplest way to create an empty object. it is now discouraged.

// 2. Using Object.create() method:
var object1 = Object.create(null);
// This method creates a new object extending the prototype object passed as a parameter.

// 3. Using the bracket's syntactig sugar:
var object2 = {};
// This is equivalent to Object.create(null) method, using a null prototype as an argument.

// 4. Using a function constructor
console.log("=== 4. Using a function constructor ===")
var Obj = function (description) {
    this.description = description
}
var object3 = new Obj("Hello. This is Obj.");
console.log("object3.description = " + object3.description);

// another example
function fObj(a: any, b: any, c: any) { this.a = a; this.b = b; this.c = c; };
var fObj123 = new fObj('111', 222, 333);
console.log(fObj);
console.log(fObj123.a + fObj123.b + fObj123.c);


// 5. Using the function constructor + prototype:
console.log("=== 5. Using the function constructor + prototype ===")
function myObj() { };
myObj.prototype.greeting = "myObj, hello";
myObj.prototype.greeting2 = "myObj, hello 2";
var k = new myObj();
console.log(k);
console.log(k.greeting);
console.log(k.greeting2);


// 6. Using ES6 class syntax:
// ref: https://hyunseob.github.io/2016/10/17/typescript-class/     Korean
console.log("=== 6. Using ES6 class syntax ===")

class myObject {
    name: string;   // field declared

    constructor(name) {
        this.name = name;
    }
}

var q6e = new myObject("hello");
console.log(q6e);
console.log("q6e.name: " + q6e.name);

// 7. Singleton pattern:
console.log("=== 7. Singleton pattern ===")
var q7l = new function () {
    this.name = "hello";
}
console.log(q7l);
console.log("q7l.name: " + q7l.name);



// 2. more detail about variables
// refer to https://www.typescriptlang.org/docs/handbook/variable-declarations.html
// NOTE: difference between var and let
// copy and paste is allowed
console.log("===== Q2. difference between var and let =====\n");

// var vs let
console.log("=== var vs let in the for loop and setTimeout ===")
// // for loop + setTimeout with var declaration
// // using var shows 10 10 10 10 ... 10
// for (var i = 0; i < 10; i++) {
//     setTimeout(function () { console.log("ex1: " + i); }, 100 * i);
// }

// // shows 0, 1, 2, 3, 4, ... 9
// for (var i = 0; i < 10; i++) {
//     // capture the current state of 'i'
//     // by invoking a function with its current value
//     (function (i) {
//         setTimeout(function () { console.log("ex2: " + i); }, 100 * i);
//     })(i);
// }

// // let fixed the var's problem
// // the principle is similiar to the above solved example
// // using let    0 1 2 3 4 5 ... 9
// for (let i = 0; i < 10; i++) {
//     setTimeout(function () { console.log("ex3: " + i); }, 100 * i);
// }

console.log("==== Re-declarations and Shadowing ====");
console.log("=== var vs let for Re-declaration ===")
// let doesn't allow re-declarations
let letReDeclaration;
//let letReDeclaration;    // throws an error

// var allows re-declarations and all the same name variables refer to the same source
var varRedeclaration;
var varRedeclaration: any = 1;
var varRedeclaration;
function testVarReDeclaration() {
    var varRedeclaration = 12;
    console.log(varRedeclaration);
}
testVarReDeclaration();
console.log(varRedeclaration);


console.log("=== re-declare var variable with let ===")
var sharedVar: any;
// let sharedVar;   // cannot re-declare by let for the same name variable


// That’s not to say that block-scoped variable can never be declared with a function-scoped variable.
// The block-scoped variable just needs to be declared within a distinctly different block.
function f(condition, x) {
    if (condition) {
        let x = 100;
        return x;
    }

    return x;
}

f(false, 0); // returns '0'
f(true, 0);  // returns '100'

// shadowing
console.log("=== Shadowing ===");
var matrix4sumTest: number[][] = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

// let allows shadowing, so each 'i' in the for loop are independent
function sumMatrix(matrix: number[][]) {
    let sum = 0;
    for (let i = 0; i < matrix.length; i++) {
        var currentRow = matrix[i];
        for (let i = 0; i < currentRow.length; i++) {
            sum += currentRow[i];
        }
    }

    return sum;
}

console.log(sumMatrix(matrix4sumTest));

// var doesn't allow shadowing, so each 'i' refers to the same i
// after the first for loop, 'i' starts with 3, but 3 is out of the secondRow's length.
// as a result, the sum is 6 which including 1, 2 and 3 only.
function sumMatrix2(matrix: number[][]) {
    let sum = 0;
    for (var i = 0; i < matrix.length; i++) {
        var currentRow = matrix[i];
        for (var i = 0; i < currentRow.length; i++) {
            sum += currentRow[i];
        }
    }

    return sum;
}

console.log(sumMatrix2(matrix4sumTest));




// 3. Generics in TypeScript
// refer to https://www.typescriptlang.org/docs/handbook/generics.html
// copy and paste is allowed

console.log("===== Q3 Generics in TypeScript =====\n");

// only number
function identityNumber(arg: number): number {
    return arg;
}
// If we passed in a number, the only information we have is that any type could be returned.
// 근데 실제론 리턴타입 정확히 잘만 나옴
function identityAny(arg: any): any {
    return arg;
}
// Instead, we need a way of capturing the type of the argument in such a way that we can also use it to denote what is being returned. 
// 
function identity<T>(arg: T): T {
    return arg;
}

console.log(typeof identityNumber(123));
console.log(typeof identityAny('abc'));
console.log(typeof identityAny('123'));
console.log(typeof identity('123'));
let q3IdentityAny1 = identityAny("myString");
let q3IdentityAny2 = identityAny(111);
console.log(typeof q3IdentityAny1); // string
console.log(typeof q3IdentityAny2); // number

let q3GeneralOutput1 = identity<string>("myString");  // type of output will be 'string'
let q3GeneralOutput2 = identity("myString");  // type of output will be 'string'
console.log(typeof q3GeneralOutput1);   // string
console.log(typeof q3GeneralOutput2);   // string

// if you wanna get the length of an arguement
function identityArray<T>(arg: T[]): T[] {
    console.log(arg.length);    // just T type doesn't have .length
    return arg;
}

let q3GeneralOutput3 = identityArray(['a', 'b', 123]);
console.log(typeof q3GeneralOutput3[2]);

// In this section, we’ll explore the type of the functions themselves and how to create generic interfaces.

let myIdentity1: <T>(arg: T) => T = identity;
let myIdentity2: <U>(arg: U) => U = identity; // We could also have used a different name for the generic type parameter in the type
let myIdentity3: { <T>(arg: T): T } = identity; // We can also write the generic type as a call signature of an object literal type:
var generalEx = myIdentity1('a');
console.log(generalEx);

// == interface ==
interface GenericIdentityFn1 {
    <T>(arg: T): T;
}

let myidentity12: GenericIdentityFn1 = identity;

interface GenericIdentityFn2<T> {
    (arg: T): T;
}
let myIdentity: GenericIdentityFn2<number> = identity;



// == generic classes ==
class GenericNumber<T> {
    zeroValue: T;
    add: (x: T, y: T) => T;
}

// Number type
let myGenericNumber = new GenericNumber<number>();
myGenericNumber.zeroValue = 0;
myGenericNumber.add = function (x, y) { return x + y; };  // assign function to the add member function

console.log(myGenericNumber.add(myGenericNumber.zeroValue, 10));

// string type
let stringNumeric = new GenericNumber<string>();
stringNumeric.zeroValue = "";
stringNumeric.add = function (x, y) { return x + y; };

console.log(stringNumeric.add(stringNumeric.zeroValue, "test"));


// == Generic Constraints ==

function loggingIdentity2<T>(arg: T): T {
    //console.log(arg.length);  // Error: T doesn't have .length
    return arg;
}

interface Lengthwise {
    length: number;
}

function loggingIdentity<T extends Lengthwise>(arg: T): T {
    console.log(arg.length);  // Now we know it has a .length property, so no more error
    return arg;
}

// loggingIdentity(3);  // Error, number doesn't have a .length property
loggingIdentity({ length: 10, value: 3 });


// == Using Type Parameters in Generic Constraints ==
function getProperty<T, K extends keyof T>(obj: T, key: K) {
    return obj[key];
}

let xx1 = { a: 1, b: 2, c: 3, d: 4 };
let xx2 = { a: 1, b: 2, c: 3, d: 4, m: 5 };

getProperty(xx1, "a"); // okay
getProperty(xx2, "m"); // okay
// getProperty(xx, "m"); // error: Argument of type 'm' isn't assignable to 'a' | 'b' | 'c' | 'd'.


// == Using Class Types in Generics ==

function create<T>(c: { new(): T; }): T {
    return new c();
}

class BeeKeeper {
    hasMask: boolean;
}

class ZooKeeper {
    nametag: string;
}

class Animal {
    numLegs: number;
}

class Bee extends Animal {
    keeper: BeeKeeper;
}

class Lion extends Animal {
    keeper: ZooKeeper;
}

function createInstance<A extends Animal>(c: new () => A): A {
    return new c();
}

//createInstance(Lion).keeper.nametag;  // typechecks!
//createInstance(Bee).keeper.hasMask;   // typechecks!




// 4. Study about "decorator" in typescript
// you can search for decorator in typescript and copy & paste code to run
// Suggestion: https://www.spectory.com/blog/A%20deep%20dive%20into%20TypeScript%20decorators
// but if you find better resource, please go ahead.
// ref: https://www.typescriptlang.org/docs/handbook/decorators.html

console.log("===== Q4. Decorator =====\n");
// A Decorator is a special kind of declaration that can be attached to a class declaration, method, accessor, property, or parameter.
// Decorators use the form @expression, where expression must evaluate to a function that will be called at runtime with information about the decorated declaration.


// ref: https://skout90.github.io/2017/08/12/Typescript/7.%20typescript-%EB%8D%B0%EC%BD%94%EB%A0%88%EC%9D%B4%ED%84%B0/
// ref: http://itmining.tistory.com/88      Korean

// === Class Decorator ===
console.log("=== Class Decorator ===");

// 인자가 없을 시엔, 생성자 함수를 선언해줘야
// 해당 클래스 틀이 선언되는 지점에서 해당 hello annotation 안의 statement가 실행됨
function hello(constructFn: Function) {
    console.log(constructFn);
}

@hello      // display: ƒ Person3() {}
class Person3 {
    greeting: string;

    greet() {
        console.log("Greeting! " + this.greeting);
    }
}

@hello      // display: ƒ Person34() {}
class Person34 {
    greeting: string;

    greet() {
        console.log("Greeting! " + this.greeting);
    }
}

// Another Class Decorator

function CarDecorator(constructor: any) {
    console.log(constructor);

    return <any>class extends constructor {
        name = 'SM6';
        color = 'red';
    }
}

@CarDecorator
class Car2 {
    name: string;
    price: number;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
    }
}

let myCar1 = new Car2('SM5', 3000);
console.log(myCar1);        // display: class_1 {name: "SM6", price: 3000, color: "red"}

// console.log(myCar1.color); causes error because color was not set as a field in the Car originally

// === Method Decorator ===
// readonly decorator (함수를 재작성할 수 없게 함)
console.log("=== Method Decorator ===");

function editable(canBeEditable: boolean) {
    return function (target: any, propName: string, description: PropertyDescriptor) {
        description.writable = canBeEditable;
    }
}

class Person4 {
    @editable(false)
    hello() {
        console.log('hello');
    }
    hello2() {
        console.log('hello');
    }
}

const p = new Person4();
p.hello(); // hello
p.hello = function () {
    console.log('world');
}
p.hello(); // hello
p.hello2 = function () {
    console.log('world');
}
p.hello2(); // hello



// === property decorator ===
console.log("=== Property Decorator ===");

function writable(canBeWritable: boolean) {
    return function (target: any, propName: string): any {
        return {
            writable: canBeWritable
        };
    }
}

class Person5 {
    @writable(false)
    name: string = "Minseok";
}

const myPerson2 = new Person5();
console.log(myPerson2.name); // Minseok
myPerson2.name = 'Min'; // error!


// === Parameter Decorator
console.log("=== Parameter Decorator ===");

// Example 1
function printInfo(target: any, methodName: string, paramIndex: number) {
    console.log(target);
    console.log(methodName);
    console.log(paramIndex);
}

class Person6 {
    private _name: string;
    private _age: number;

    constructor(name: string, @printInfo age: number) {
        this._name = name;
        this._age = age;
    }

    hello(@printInfo message: string) {
        console.log(message);
    }
}

// Example 2
function ClassDecorator2(param: any) {
    console.log(param); // {someValue: "hello!"}
    return function (constructor: any) {
        console.log(constructor);
        // Display:
        // ƒ Car(name, price) {
        //   this.name = name;
        //   this.price = price;
        // }
        return <any>class extends constructor {
            someValue = param.someValue + ' world!';
        }
    }
}

@ClassDecorator2({ someValue: 'hello!' })
class Car3 {
    name: string;
    price: number;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
    }
}

