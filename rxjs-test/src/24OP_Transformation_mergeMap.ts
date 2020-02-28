/**
 Map to observable, emit values.

1. flatMap is an alias for mergeMap!
2. If only one inner subscription should be active at a time, try switchMap!
3. If the order of emission and subscription of inner observables is important, try concatMap!

 */
/*
This operator is best used when you wish to flatten an inner observable but want to manually control the number of inner subscriptions.
For instance, when using switchMap each inner subscription is completed when the source emits, allowing only one active inner subscription. 
In contrast, mergeMap allows for multiple inner subscriptions to be active at a time. Because of this, 
one of the most common use-case for mergeMap is requests that should not be canceled, think writes rather than reads. 
Note that if order must be maintained concatMap is a better option.

Be aware that because mergeMap maintains multiple active inner subscriptions at once it's possible to create a memory leak through long-lived inner subscriptions. 
A basic example would be if you were mapping to an observable with an inner timer, or a stream of dom events. 
In these cases, if you still wish to utilize mergeMap you may want to take advantage of another operator 
to manage the completion of the inner subscription, think take or takeUntil. 

You can also limit the number of active inner subscriptions at a time with the concurrent parameter,
*/

// 1. mergeMap with observable
// RxJS v6+
import { of, interval } from 'rxjs';
import { mergeMap, take } from 'rxjs/operators';

//emit 'Hello'
const source = of('Hello');
//map to inner observable and flatten
const example = source.pipe(mergeMap(val => of(`${val} World!`)));
//output: 'Hello World!'
const subscribe = example.subscribe(val => console.log(val));


// 2. mergeMap with promise ( promise is like delegate )
//emit 'Hello'
const source2 = of('Hello');
//mergeMap also emits result of promise
const myPromise = val => new Promise(resolve => resolve(`${val} World From Promise!`));
//map to promise and emit result
const example2 = source2.pipe(mergeMap(val => myPromise(val)));
//output: 'Hello World From Promise'
const subscribe2 = example2.subscribe(val => console.log(val));

// 3. mergeMap with resultSelector
// RxJS v6+
/*
  you can also supply a second argument which receives the source value and emitted
  value of inner observable or promise
*/
//emit 'Hello'
const source3 = of('Hello');
//mergeMap also emits result of promise
const myPromise2 = val =>
  new Promise(resolve => resolve(`${val} World From Promise!`));
const example3 = source3.pipe(
  mergeMap(
    val => myPromise(val),
    (valueFromSource, valueFromPromise) => {
      return `Source: ${valueFromSource}, Promise: ${valueFromPromise}`;
    }
  )
);
//output: "Source: Hello, Promise: Hello World From Promise!"
const subscribe3 = example3.subscribe(val => console.log(val));


// 4. mergeMap with concurrent value
//emit value every 1s
const source4 = interval(1000);

const example4 = source.pipe(
  mergeMap(
    //project
    val => interval(5000).pipe(take(2)),
    //resultSelector
    (oVal, iVal, oIndex, iIndex) => [oIndex, oVal, iIndex, iVal],
    //concurrent
    2
  )
);
/*
        Output:
        [0, 0, 0, 0] <--1st inner observable
        [1, 1, 0, 0] <--2nd inner observable
        [0, 0, 1, 1] <--1st inner observable
        [1, 1, 1, 1] <--2nd inner observable
        [2, 2, 0, 0] <--3rd inner observable
        [3, 3, 0, 0] <--4th inner observable
*/
const subscribe4 = example4.subscribe(val => console.log(val));