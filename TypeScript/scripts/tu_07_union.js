// Two or more data types are combined using the pipe symbol (|) to denote a Union Type
// NOTE: confirm how it is changed to javascript
var val; // union type; string이 될수도 있고 number가 될수도 있다
val = 12;
console.log("numeric value of val " + val);
val = "This is a string";
console.log("string value of val " + val);
// union type and function parameter
function disp7(name) {
    if (typeof name == "string") { // typeof는 변수의 type을 알고자 할 때 씀
        console.log(name);
    }
    else {
        // var i;        
        for (var i = 0; i < name.length; i++) {
            console.log(name[i]);
        }
    }
}
disp7("mark");
console.log("Printing names array....");
disp7(["Mark", "Tom", "Mary", "John"]);
// union type and arrays
var arr7;
var i;
arr7 = [1, 2, 4];
console.log("**numeric array**");
for (i = 0; i < arr7.length; i++) {
    console.log(arr7[i]);
}
arr7 = ["Mumbai", "Pune", "Delhi"];
console.log("**string array**");
for (i = 0; i < arr7.length; i++) {
    console.log(arr7[i]);
}
//# sourceMappingURL=tu_07_union.js.map