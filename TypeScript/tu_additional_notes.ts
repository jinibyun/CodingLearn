
// // https://www.typescriptlang.org/docs/handbook/variable-declarations.html

// // var vs let
// console.log("=== var vs let in the for loop and setTimeout ===")
// // for loop + setTimeout with var declaration
// // using var shows 10 10 10 10 ... 10
// for (var i = 0; i < 10; i++) {
//     setTimeout(function () { console.log(i); }, 100 * i);
// }

// // shows 0, 1, 2, 3, 4, ... 9
// for (var i = 0; i < 10; i++) {
//     // capture the current state of 'i'
//     // by invoking a function with its current value
//     (function (i) {
//         setTimeout(function () { console.log(i); }, 100 * i);
//     })(i);
// }

// // let fixed the var's problem
// // the principle is similiar to the above solved example
// // using let    0 1 2 3 4 5 ... 9
// for (let i = 0; i < 10; i++) {
//     setTimeout(function () { console.log(i); }, 100 * i);
// }

// console.log("=== var vs let for Re-declaration ===")
// let letReDeclaration;
// //let letReDeclaration;    // throws an error

// var varRedeclaration;
// var varRedeclaration:any = 1;
// var varRedeclaration;
// function testVarReDeclaration() {
//     var varRedeclaration = 12;
//     console.log(varRedeclaration);
// }
// testVarReDeclaration();
// console.log(varRedeclaration);


// // declaration order
// console.log("=== declaration order ===")

// // it works as lon as 'ab' declared in the same scope.
// function foo22() {
//     // okay to capture 'a'
//     return ab;
// }

// // illegal call 'foo' before 'a' is declared
// // runtimes should throw an error here  // actually it doesn't throw an error
// console.log(foo22());   // display 'undefined'
// let ab = 123;
// console.log(foo22());   // display '123'
