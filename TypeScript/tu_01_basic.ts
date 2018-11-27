// basic
var message: string = "Hello World"; // message is declared with string type. var is declaration
console.log(message);

// class
class Greeting {
    greet(): void {
        console.log("This is test");
    }
}

var obj = new Greeting();
obj.greet();

// type:
// 1. "any" data type is the supoer type of all types in TypeSecript. It denotes a dynamic type.
// 2. Built-in types
/*
    > number: Double precision 64-bit floating point values. It can be used to represent both, integers and fractions. (NOTE: no integer type)
    > string
    > boolean
    > void
    > null
    > undefined
*/

// variable
// The type syntax for declaring a variable in TypeScript is to include a colon(:) after the variable name, followed by its type. If it is omitted, then its type will be set to any
var name2: string = "John";
var score1: number = 50;
var score2: number = 42.50;
var sum = score1 + score2; // 기본적으로 type은 sum:any로 되어있다(그냥 생략 됨). 아무 타입이나 받을 수 있다.
//var sum2:any = score1 = score2;
console.log("name" + name2);
console.log("first score: " + score1);
console.log("second score: " + score2);
console.log("sum of the scores: " + sum);

// type assertion
var str = '1';  // 이 경우 무조건 string 타입
var str2: number = <number><any>str   //str is now of type number 먼저 any타입으로 convert한 다음 number type으로 바꾸는 것.
// any를 중간에 꼭 넣어야 함. 안넣으면 typescript 자체적으로 complain함.
console.log("type assertion: " + str2);

// inferred typing: build error
// var num = 2;    // data type inferred as number     이런 식으로 선언하면 type은 any와 같음 (num:any)
// 그래도 일단 처음에 들어간 value의 타입에 의해 num의 타입은 number로 정해짐
// console.log("value of num "+num); 
// num = "12";
// console.log(num);

// variable scope
var global_num = 12;          //global variable 
class Numbers {
    num_val = 13;             //class variable : class 안에서는 var를 붙이지 않는다. 붙이면 error남
    static sval = 10;         //static field 

    storeNum(): void {
        var local_num = 14;    //local variable 
    }
}
console.log("Global num: " + global_num);
console.log(Numbers.sval);   //static variable  
var obj2 = new Numbers();
console.log("Global num: " + obj2.num_val);