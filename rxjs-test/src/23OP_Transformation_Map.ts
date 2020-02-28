/*
Apply projection with each value from source.
*/

// 1
// RxJS v6+
import { from } from 'rxjs';
import { map } from 'rxjs/operators';

//emit (1,2,3,4,5)
const source = from([1, 2, 3, 4, 5]);
//add 10 to each value
const example = source.pipe(map(val => val + 10));
//output: 11,12,13,14,15
const subscribe = example.subscribe(val => console.log(val));


// 2
// RxJS v6+
//emit ({name: 'Joe', age: 30}, {name: 'Frank', age: 20},{name: 'Ryan', age: 50})
const source2 = from([
  { name: 'Joe', age: 30 },
  { name: 'Frank', age: 20 },
  { name: 'Ryan', age: 50 }
]);
//grab each persons name, could also use pluck for this scenario
const example2 = source2.pipe(map(({ name }) => name));
//output: "Joe","Frank","Ryan"
const subscribe2 = example2.subscribe(val => console.log(val));
