/*
Turn an array, promise, or iterable into an observable.
*/

/*
1. This operator can be used to convert a promise to an observable!
2. For arrays and iterables, all contained values will be emitted as a sequence!
3. This operator can also be used to emit a string as a sequence of characters!
*/


// 1. observable from array
// RxJS v6+
import { from } from 'rxjs';

//emit array as a sequence of values
const arraySource = from([1, 2, 3, 4, 5]);


//output: 1,2,3,4,5
const subscribe = arraySource.subscribe(val => console.log(val));

// 2. Observable from promise
// RxJS v6+

//emit result of promise
const promiseSource = from(new Promise(resolve => resolve('Hello World!')));
//output: 'Hello World'
const subscribe2 = promiseSource.subscribe(val => console.log(val));

// 3. Observable from collection
//works on js collections : It is like dictionary in c#
const map = new Map();
map.set(1, 'Hi');
map.set(2, 'Bye');

const mapSource = from(map);
//output: [1, 'Hi'], [2, 'Bye']
const subscribe3 = mapSource.subscribe(val => console.log(val));

// 4. Observable from string

// RxJS v6+
//emit string as a sequence
const source = from('Hello World');

//output: 'H','e','l','l','o',' ','W','o','r','l','d'
const subscribe4 = source.subscribe(val => console.log(val));
