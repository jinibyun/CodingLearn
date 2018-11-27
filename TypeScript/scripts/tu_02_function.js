console.log("-------------- 1 calling functions --------------");
// function with return type
function greet() {
    return "Hello World";
}
function caller() {
    var msg = greet();
    console.log(msg);
}
caller();
console.log("Coller called");
console.log("------------- 2 function with parameters ---------------");
// function with parameters
// if data type is omitted, then it will be set to "any"
function test_param(n1, s1) {
    console.log(n1);
    console.log(s1);
}
test_param(123, "this is a string");
console.log("-------------- 3 optional parameters --------------");
// optional parameters
// mail_id? is the optional parameter. it can be omiited when overloading the function to call
function disp_details(id, name, mail_id) {
    console.log("ID ", id);
    console.log("Name", name);
    if (mail_id != undefined) { // undefined는 defined되지 않은 것을 말함. NULL과는 다름. 그냥 아예 없는 것.
        console.log("Email Id", mail_id);
    }
}
disp_details(123, "John");
disp_details(111, "mary", "mary@xyz.com");
console.log("------------- 4 default parameters ---------------");
// default parameters
// rate:number에 값이 주어지지 않으면 default로 0.50를 갖음
function calculate_discount(price, rate) {
    if (rate === void 0) { rate = 0.50; }
    var discount = price * rate;
    console.log("Discount Amount: ", discount);
}
calculate_discount(1000);
calculate_discount(1000, 0.30);
console.log("--------------- 5 rest parameters ----------------");
// rest parameters: 
// don't restirct the number of values that you can pass to a function. 
// NOTE: the values passed must all be of the same type.
// HOW: the parmeter name is prefixed with threee periods.
// C#에 params 키워드와 비슷
function addNumbers() {
    var nums = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        nums[_i] = arguments[_i];
    }
    var i;
    var sum = 0;
    for (i = 0; i < nums.length; i++) {
        sum = sum + nums[i];
    }
    console.log("sum of the numbers", sum);
}
addNumbers(1, 2, 3);
addNumbers(10, 10, 10, 10, 10);
console.log("--------------- 6 anonymous function ----------------");
// anonymous function
// It is dynamically declared at runtime
// Variables can be assigned an anonymous function. Such an expressin is called a function expression.
// C#에서 Delegate와 같음
// 굉장히 많이 쓰임
var msg = function () {
    return "hello world";
};
console.log(msg());
var res = function (a, b) {
    return a * b;
};
console.log(res(12, 2));
// NOTE
/*
인터뷰문제로 나왔었다.
variable로 선언한 function과 그냥 평범하게 선언된 function과의 차이:
컴파일 할 때 syntax 검사를 함. 그 때 Function은 parsing(Syntax check)을 미리 하는데
anoynimous function은 그 function이 실행될 때만 partsing이 됨. 그 차이가 있다.

그렇게 차이를 두는 이유는 C#에서 delegate를 method에 넘기는 것과 비슷..?
그래서 조건에 따라 받은 method를 실행할수도 있고 안할수도 있는데 안하면 parsing할 이유가 없음

The fundamental difference between the two is that,
 function declarations are parsed before their execution.
  On the other hand, function expressions are parsed only
  when the script engine encounters it during execution.

  


When the JavaScript parser sees a function in the main code flow,
 it assumes Function Declaration. When a function comes as a part of a statement,
  it is a Function Expression.
*/
console.log("-------------Function Constructor: built-in JavaScript contructor called Function() ---------------");
// Function Constructor: built-in JavaScript contructor called Function()
var myFunction = new Function("a", "b", "return a * b");
var x = myFunction(4, 3);
console.log(x);
console.log("-------------- Recursion --------------");
// Recursion
function factorial(number) {
    if (number <= 0) { // termination case
        return 1;
    }
    else {
        return (number * factorial(number - 1));
    }
}
console.log(factorial(6));
console.log("factorial(6)");
console.log("--------------- Anonymous recursive function -------------");
// Anonymous recursive function
(function () {
    var x = "Hello";
    console.log(x);
})(); // the function invokes itself using a pair of parentheses(); 이름이 없어서 이렇게 실행한다
console.log("-------------- Lambda function --------------");
// Lambda function
// Lambda refers to anonymous function in programming.
// Lambda functions are a concise mechanism to represent anonymous functions. 
// Three parts: parameters, => (goes to operator), statement
// foo가 anonymous function memory address를 갖고 있다
var foo = function (x) { return 10 + x; }; // 왼쪽이 parameter, 오른쪽이 함수 body
console.log(foo(100));
// when it has over 2 lines, use {} and return for returning a value
var foo2 = function (x) {
    x = x + 10;
    console.log(x);
};
foo2(100);
console.log("--------------- Syntactic Variations --------------");
// Syntactic Variations
// It is not mandatory to specify the data type of a parameter. In such a case, the data type of the parameter is "any".
var func = function (x) {
    if (typeof x == "number") {
        console.log(x + " is numeric");
    }
    else if (typeof x == "string") {
        console.log(x + " is a string");
    }
};
func(12);
func("Jini");
console.log("-------------------------------");
// optional parentheses for a single parameter and no parameter
// input 없으면 var display = () => {}
// input 있으면 var display = (x) => {}, 근데 하나 뿐이면 x만 해도 됨
var display = function (x) {
    console.log("The function got " + x);
};
display(12);
var disp = function () {
    console.log("Function invoked");
};
disp();
console.log("-------------------------------");
function disp5(x, y) {
    console.log(x);
    console.log(y);
}
disp5("abc");
disp5(1, "xyz");
console.log("-------------------------------");
//# sourceMappingURL=tu_02_function.js.map