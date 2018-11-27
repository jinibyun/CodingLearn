// array
// var array_name : datatype[];        //declaration 
// array_name = [val1,val2,valn..]   //initialization
// e.g var numlist:number[] = [2,4,6,8];  여기서 []안에 숫자를 넣으면 안된다!
// JavaScript Technical Interview 문제는 하루만에 준비할 수 있는 양이 아니다. 평소에 준비할 수 밖에 없는데..
// 바로 당장 인터뷰 있다면 그냥 잠 자는게 나음
// 근데 꼭해야한다면 Array쪽을 공부하는 게 나음
console.log("======== Array =========");
var alphas;
alphas = ["1", "2", "3", "4"];
console.log(alphas[0]);
console.log(alphas[1]);
var nums = [1, 2, 3, 3];
console.log(nums[0]);
console.log(nums[1]);
console.log(nums[2]);
console.log(nums[3]);
console.log("========= Array Object ========");
// Array Object
// An array can also be created using the Array object. The Array constructor can be passed.
console.log("Array Object");
var arr_names = new Array(4); // 방 4개짜리 Array
for (var i = 0; i < arr_names.length; i++) {
    arr_names[i] = i * 2;
    console.log(arr_names[i]);
}
var names = new Array("Mary", "Tom", "Jack", "Jill");
for (var i = 0; i < names.length; i++) {
    console.log(names[i]);
}
console.log("======== array traverse =========");
// array traverse
var j;
var nums = [1001, 1002, 1003, 1004];
for (j in nums) {
    console.log(nums[j]);
}
console.log("========= Array object method ========");
// Array object method
console.log("========= Two-Dimensional Array ========");
// Two-Dimensional Array
var multi = [[1, 2, 3], [23, 24, 25]];
console.log(multi[0][0]);
console.log(multi[0][1]);
console.log(multi[0][2]);
console.log(multi[1][0]);
console.log(multi[1][1]);
console.log(multi[1][2]);
console.log("======== passing array to function =========");
// passing array to function
var names = new Array("Mary", "Tom", "Jack", "Jill");
function disp2(arr_names) {
    for (var i = 0; i < arr_names.length; i++) {
        console.log(names[i]);
    }
}
disp2(names);
console.log("======== return array from function =========");
// return array from function
function disp3() {
    return new Array("Jack", "Queen", "King");
}
var nums3 = disp3();
for (var i2 in nums3) {
    console.log(nums3[i2]);
}
//# sourceMappingURL=tu_05_array.js.map