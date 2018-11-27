// You can create "assignment" folder on your typescript project
// Unless the folder is excluded in "tsconfig.json", once you command "tsc", it will transcomplie all your ts files
// and it will generate relevant js files under "scripts" folder as we did it in classroom.
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
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
console.log("=== 4. Using a function constructor ===");
var Obj = function (description) {
    this.description = description;
};
var object3 = new Obj("Hello. This is Obj.");
console.log("object3.description = " + object3.description);
// another example
function fObj(a, b, c) { this.a = a; this.b = b; this.c = c; }
;
var fObj123 = new fObj('111', 222, 333);
console.log(fObj);
console.log(fObj123.a + fObj123.b + fObj123.c);
// 5. Using the function constructor + prototype:
console.log("=== 5. Using the function constructor + prototype ===");
function myObj() { }
;
myObj.prototype.greeting = "myObj, hello";
myObj.prototype.greeting2 = "myObj, hello 2";
var k = new myObj();
console.log(k);
console.log(k.greeting);
console.log(k.greeting2);
// 6. Using ES6 class syntax:
// ref: https://hyunseob.github.io/2016/10/17/typescript-class/     Korean
console.log("=== 6. Using ES6 class syntax ===");
var myObject = /** @class */ (function () {
    function myObject(name) {
        this.name = name;
    }
    return myObject;
}());
var q6e = new myObject("hello");
console.log(q6e);
console.log("q6e.name: " + q6e.name);
// 7. Singleton pattern:
console.log("=== 7. Singleton pattern ===");
var q7l = new function () {
    this.name = "hello";
};
console.log(q7l);
console.log("q7l.name: " + q7l.name);
// 2. more detail about variables
// refer to https://www.typescriptlang.org/docs/handbook/variable-declarations.html
// NOTE: difference between var and let
// copy and paste is allowed
console.log("===== Q2. difference between var and let =====\n");
// var vs let
console.log("=== var vs let in the for loop and setTimeout ===");
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
console.log("=== var vs let for Re-declaration ===");
// let doesn't allow re-declarations
var letReDeclaration;
//let letReDeclaration;    // throws an error
// var allows re-declarations and all the same name variables refer to the same source
var varRedeclaration;
var varRedeclaration = 1;
var varRedeclaration;
function testVarReDeclaration() {
    var varRedeclaration = 12;
    console.log(varRedeclaration);
}
testVarReDeclaration();
console.log(varRedeclaration);
console.log("=== re-declare var variable with let ===");
var sharedVar;
// let sharedVar;   // cannot re-declare by let for the same name variable
// That’s not to say that block-scoped variable can never be declared with a function-scoped variable.
// The block-scoped variable just needs to be declared within a distinctly different block.
function f(condition, x) {
    if (condition) {
        var x_1 = 100;
        return x_1;
    }
    return x;
}
f(false, 0); // returns '0'
f(true, 0); // returns '100'
// shadowing
console.log("=== Shadowing ===");
var matrix4sumTest = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
// let allows shadowing, so each 'i' in the for loop are independent
function sumMatrix(matrix) {
    var sum = 0;
    for (var i_1 = 0; i_1 < matrix.length; i_1++) {
        var currentRow = matrix[i_1];
        for (var i_2 = 0; i_2 < currentRow.length; i_2++) {
            sum += currentRow[i_2];
        }
    }
    return sum;
}
console.log(sumMatrix(matrix4sumTest));
// var doesn't allow shadowing, so each 'i' refers to the same i
// after the first for loop, 'i' starts with 3, but 3 is out of the secondRow's length.
// as a result, the sum is 6 which including 1, 2 and 3 only.
function sumMatrix2(matrix) {
    var sum = 0;
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
function identityNumber(arg) {
    return arg;
}
// If we passed in a number, the only information we have is that any type could be returned.
// 근데 실제론 리턴타입 정확히 잘만 나옴
function identityAny(arg) {
    return arg;
}
// Instead, we need a way of capturing the type of the argument in such a way that we can also use it to denote what is being returned. 
// 
function identity(arg) {
    return arg;
}
console.log(typeof identityNumber(123));
console.log(typeof identityAny('abc'));
console.log(typeof identityAny('123'));
console.log(typeof identity('123'));
var q3IdentityAny1 = identityAny("myString");
var q3IdentityAny2 = identityAny(111);
console.log(typeof q3IdentityAny1); // string
console.log(typeof q3IdentityAny2); // number
var q3GeneralOutput1 = identity("myString"); // type of output will be 'string'
var q3GeneralOutput2 = identity("myString"); // type of output will be 'string'
console.log(typeof q3GeneralOutput1); // string
console.log(typeof q3GeneralOutput2); // string
// if you wanna get the length of an arguement
function identityArray(arg) {
    console.log(arg.length); // just T type doesn't have .length
    return arg;
}
var q3GeneralOutput3 = identityArray(['a', 'b', 123]);
console.log(typeof q3GeneralOutput3[2]);
// In this section, we’ll explore the type of the functions themselves and how to create generic interfaces.
var myIdentity1 = identity;
var myIdentity2 = identity; // We could also have used a different name for the generic type parameter in the type
var myIdentity3 = identity; // We can also write the generic type as a call signature of an object literal type:
var generalEx = myIdentity1('a');
console.log(generalEx);
var myidentity12 = identity;
var myIdentity = identity;
// == generic classes ==
var GenericNumber = /** @class */ (function () {
    function GenericNumber() {
    }
    return GenericNumber;
}());
// Number type
var myGenericNumber = new GenericNumber();
myGenericNumber.zeroValue = 0;
myGenericNumber.add = function (x, y) { return x + y; }; // assign function to the add member function
console.log(myGenericNumber.add(myGenericNumber.zeroValue, 10));
// string type
var stringNumeric = new GenericNumber();
stringNumeric.zeroValue = "";
stringNumeric.add = function (x, y) { return x + y; };
console.log(stringNumeric.add(stringNumeric.zeroValue, "test"));
// == Generic Constraints ==
function loggingIdentity2(arg) {
    //console.log(arg.length);  // Error: T doesn't have .length
    return arg;
}
function loggingIdentity(arg) {
    console.log(arg.length); // Now we know it has a .length property, so no more error
    return arg;
}
// loggingIdentity(3);  // Error, number doesn't have a .length property
loggingIdentity({ length: 10, value: 3 });
// == Using Type Parameters in Generic Constraints ==
function getProperty(obj, key) {
    return obj[key];
}
var xx1 = { a: 1, b: 2, c: 3, d: 4 };
var xx2 = { a: 1, b: 2, c: 3, d: 4, m: 5 };
getProperty(xx1, "a"); // okay
getProperty(xx2, "m"); // okay
// getProperty(xx, "m"); // error: Argument of type 'm' isn't assignable to 'a' | 'b' | 'c' | 'd'.
// == Using Class Types in Generics ==
function create(c) {
    return new c();
}
var BeeKeeper = /** @class */ (function () {
    function BeeKeeper() {
    }
    return BeeKeeper;
}());
var ZooKeeper = /** @class */ (function () {
    function ZooKeeper() {
    }
    return ZooKeeper;
}());
var Animal = /** @class */ (function () {
    function Animal() {
    }
    return Animal;
}());
var Bee = /** @class */ (function (_super) {
    __extends(Bee, _super);
    function Bee() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Bee;
}(Animal));
var Lion = /** @class */ (function (_super) {
    __extends(Lion, _super);
    function Lion() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Lion;
}(Animal));
function createInstance(c) {
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
// For example, given the decorator @sealed we might write the sealed function as follows:
function sealed(target) {
    // do something with 'target' ...
}
// If we want to customize how a decorator is applied to a declaration,
// we can write a decorator factory. A Decorator Factory is simply a function that
// returns the expression that will be called by the decorator at runtime.
function color(value) {
    return function (target) {
        // do something with 'target' and 'value'...
    };
}
// ref: https://skout90.github.io/2017/08/12/Typescript/7.%20typescript-%EB%8D%B0%EC%BD%94%EB%A0%88%EC%9D%B4%ED%84%B0/
// === Class Decorator ===
console.log("=== Class Decorator ===");
// 인자가 없을 시엔, 생성자 함수를 선언해줘야
// 해당 클래스 틀이 선언되는 지점에서 해당 hello annotation 안의 statement가 실행됨
function hello(constructFn) {
    console.log(constructFn);
}
var Person3 = /** @class */ (function () {
    function Person3() {
    }
    Person3.prototype.greet = function () {
        console.log("Greeting! " + this.greeting);
    };
    Person3 = __decorate([
        hello // display: ƒ Person3() {}
    ], Person3);
    return Person3;
}());
var Person34 = /** @class */ (function () {
    function Person34() {
    }
    Person34.prototype.greet = function () {
        console.log("Greeting! " + this.greeting);
    };
    Person34 = __decorate([
        hello // display: ƒ Person34() {}
    ], Person34);
    return Person34;
}());
// Another Class Decorator
function CarDecorator(constructor) {
    console.log(constructor);
    return /** @class */ (function (_super) {
        __extends(class_1, _super);
        function class_1() {
            var _this = _super !== null && _super.apply(this, arguments) || this;
            _this.name = 'SM6';
            _this.color = 'red';
            return _this;
        }
        return class_1;
    }(constructor));
}
var Car2 = /** @class */ (function () {
    function Car2(name, price) {
        this.name = name;
        this.price = price;
    }
    Car2 = __decorate([
        CarDecorator
    ], Car2);
    return Car2;
}());
var myCar1 = new Car2('SM5', 3000);
console.log(myCar1); // display: class_1 {name: "SM6", price: 3000, color: "red"}
// console.log(myCar1.color); causes error because color was not set as a field in the Car originally
// === Method Decorator ===
// readonly decorator (함수를 재작성할 수 없게 함)
console.log("=== Method Decorator ===");
function editable(canBeEditable) {
    return function (target, propName, description) {
        description.writable = canBeEditable;
    };
}
var Person4 = /** @class */ (function () {
    function Person4() {
    }
    Person4.prototype.hello = function () {
        console.log('hello');
    };
    Person4.prototype.hello2 = function () {
        console.log('hello');
    };
    __decorate([
        editable(false)
    ], Person4.prototype, "hello", null);
    return Person4;
}());
var p = new Person4();
p.hello(); // hello
p.hello = function () {
    console.log('world');
};
p.hello(); // hello
p.hello2 = function () {
    console.log('world');
};
p.hello2(); // hello
// === property decorator ===
console.log("=== Property Decorator ===");
function writable(canBeWritable) {
    return function (target, propName) {
        return {
            writable: canBeWritable
        };
    };
}
var Person5 = /** @class */ (function () {
    function Person5() {
        this.name = "Minseok";
    }
    __decorate([
        writable(false)
    ], Person5.prototype, "name", void 0);
    return Person5;
}());
var myPerson2 = new Person5();
console.log(myPerson2.name); // Minseok
myPerson2.name = 'Min'; // error!
// === Parameter Decorator
console.log("=== Parameter Decorator ===");
// Example 1
function printInfo(target, methodName, paramIndex) {
    console.log(target);
    console.log(methodName);
    console.log(paramIndex);
}
var Person6 = /** @class */ (function () {
    function Person6(name, age) {
        this._name = name;
        this._age = age;
    }
    Person6.prototype.hello = function (message) {
        console.log(message);
    };
    __decorate([
        __param(0, printInfo)
    ], Person6.prototype, "hello", null);
    Person6 = __decorate([
        __param(1, printInfo)
    ], Person6);
    return Person6;
}());
// Example 2
function ClassDecorator2(param) {
    console.log(param); // {someValue: "hello!"}
    return function (constructor) {
        console.log(constructor);
        // Display:
        // ƒ Car(name, price) {
        //   this.name = name;
        //   this.price = price;
        // }
        return /** @class */ (function (_super) {
            __extends(class_2, _super);
            function class_2() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.someValue = param.someValue + ' world!';
                return _this;
            }
            return class_2;
        }(constructor));
    };
}
var Car3 = /** @class */ (function () {
    function Car3(name, price) {
        this.name = name;
        this.price = price;
    }
    Car3 = __decorate([
        ClassDecorator2({ someValue: 'hello!' })
    ], Car3);
    return Car3;
}());
//# sourceMappingURL=Assignment1.js.map