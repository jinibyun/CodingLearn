// tuple
// tuples enable storing multiple fields of different types
// tuple은 모든 Language에 다 있다. 조금씩 다르지만..
// 아무 데이터타입의 value를 넣을 수 있는 Datatable과 비슷하다. Table은 아니지만
// 검색하자
// 배열의 정의는 같은 데이터타입 값들의 저장소
// tuple은 배열의 정의에서 벗어나 있으니 배열이 아니다.
// tuple은 tuple이다.
var mytuple = [10, "Hello"];
console.log(mytuple[0]);
console.log(mytuple[1]);
var mytuple2 = [];
mytuple2[0] = "abcde";
mytuple2[1] = true;
console.log(mytuple2[0]);
console.log(mytuple2[1]);
// tuple operation
var mytuple3 = [10, "Hello", "World", "typeScript"];
console.log("Items before push " + mytuple3.length); // returns the tuple size 
mytuple3.push(12); // append value to the tuple 
console.log("Items after push " + mytuple3.length);
console.log("Items before pop " + mytuple3.length);
console.log(mytuple3.pop() + " popped from the tuple"); // removes and returns the last item
// 마지막으로 넣은 게 처음으로 나왔다. Tuple은 LIFO이다.
// LIFO(Last input First output); FIFO (First input First output)
console.log("Items after pop " + mytuple3.length);
// updating tuples
var mytuple4 = [10, "Hello", "World", "typeScript"]; //create a  tuple 
console.log("Tuple value at index 0 " + mytuple4[0]);
//update a tuple element 
mytuple[0] = 1214;
console.log("Tuple value at index 0 changed to   " + mytuple[0]);
//# sourceMappingURL=tu_06_tuple.js.map