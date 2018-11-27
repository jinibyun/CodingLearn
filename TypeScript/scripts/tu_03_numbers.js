// Number
console.log("TypeScript Number Properties: ");
console.log("Maximum value that a number variable can hold: " + Number.MAX_VALUE);
console.log("The least value that a number variable can hold: " + Number.MIN_VALUE);
console.log("Value of Negative Infinity: " + Number.NEGATIVE_INFINITY);
console.log("Value of Negative Infinity:" + Number.POSITIVE_INFINITY);
console.log("===== NaN : Not a Number =====");
// NaN : Not a Number
var month = 15;
if (month <= 0 || month > 12) {
    month = Number.NaN;
    console.log("Month is " + month); // output: Month is NaN
}
else {
    console.log("Value Accepted..");
}
// JavaScript에선 function 자체가 object로 아래처럼 쓰일 수도 있음!
// prototype
console.log("======== prototype ======");
function abc(id) {
    this.id = id;
}
function employee(id, name) {
    this.id = id;
    this.name = name;
}
var emp = new employee(123, "Smith");
employee.prototype.email = "smith@abc.com";
// JavaScript내 모든 objects는 무조건 자동으로 생성되는 하나의 property가 있는데 prototype임
// prototype은 추가적인 property를 갖을 수 있도록 해줌
// C#의 Extension이라고 볼 수 있음.
console.log("Employee 's Id: " + emp.id);
console.log("Employee's name: " + emp.name);
console.log("Employee's Email ID: " + emp.email);
//# sourceMappingURL=tu_03_numbers.js.map