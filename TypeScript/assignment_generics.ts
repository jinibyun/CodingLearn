function identity(arg: number): number {
    return arg;
}

function identity2(arg: any): any {
    return arg;
}

function identity3<T>(arg: T): T {
    return arg;
}

let output1 = identity3<string>("myString");  // type of output will be 'string'
let output2 = identity3("myString");  // type of output will be 'string'

//function loggingIdentity<T>(arg: T): T {
//    console.log(arg.length);  // Error: T doesn't have .length
//   return arg;
//}

function loggingIdentity<T>(arg: T[]): T[] {
    console.log(arg.length);  // Array has a .length, so no more error
    return arg;
}

let myIdentity1: <T>(arg: T) => T = identity3;
let myIdentity2: <U>(arg: U) => U = identity3;
let myIdentity3: {<T>(arg: T): T} = identity3;

interface GenericIdentityFn {
    <T>(arg: T): T;
}

function identity4<T>(arg: T): T {
    return arg;
}

let myIdentity4: GenericIdentityFn = identity4;

interface GenericIdentityFn2<T> {
    (arg: T): T;
}

function identity5<T>(arg: T): T {
    return arg;
}

let myIdentity5: GenericIdentityFn2<number> = identity5;

console.log("*** Generic Classes ***");

class GenericNumber<T> {
    zeroValue: T;
    add: (x: T, y: T) => T;
}

let myGenericNumber = new GenericNumber<number>();
myGenericNumber.zeroValue = 0;
myGenericNumber.add = function(x, y) { return x + y; };

let stringNumeric = new GenericNumber<string>();
stringNumeric.zeroValue = "";
stringNumeric.add = function(x, y) { return x + y; };

console.log(stringNumeric.add(stringNumeric.zeroValue, "test"));

console.log("*** Generic Constraints ***");
//function loggingIdentity<T>(arg: T): T {
//    console.log(arg.length);  // Error: T doesn't have .length
//    return arg;
//}

interface Lengthwise {
    length: number;
}

function loggingIdentity1<T extends Lengthwise>(arg: T): T {
    console.log(arg.length);  // Now we know it has a .length property, so no more error
    return arg;
}

//loggingIdentity(3);  // Error, number doesn't have a .length property
loggingIdentity1({length: 10, value: 3});

console.log("*** Using Type Parameters in Generic Constraints ***");
function getProperty<T, K extends keyof T>(obj: T, key: K) {
    return obj[key];
}

let z = { a: 1, b: 2, c: 3, d: 4 };

getProperty(z, "a"); // okay
//getProperty(z, "m"); // error: Argument of type 'm' isn't assignable to 'a' | 'b' | 'c' | 'd'.

console.log("*** Using Class Types in Generics***");
function create<T>(c: {new(): T; }): T {
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

createInstance(Lion).keeper.nametag;  // typechecks!
createInstance(Bee).keeper.hasMask;   // typechecks!