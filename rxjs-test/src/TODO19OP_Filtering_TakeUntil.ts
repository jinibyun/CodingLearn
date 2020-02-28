/*
Emit values until provided observable emits.
*/

// If you only need a specific number of values, try take!


// 1
// RxJS v6+
import { interval, timer } from 'rxjs';
import { takeUntil, filter, scan, map, withLatestFrom } from 'rxjs/operators';

// //emit value every 1s
// const source = interval(1000);
// //after 5 seconds, emit value
// const timer$ = timer(5000);
// //when timer emits after 5s, complete source
// const example = source.pipe(takeUntil(timer$));
// //output: 0,1,2,3
// const subscribe = example.subscribe(val => console.log(val));


// 2
// RxJS v6+
//emit value every 1s
const source2 = interval(1000);

//is number even?
// It is like delegate.
const isEven = val => val % 2 === 0;

//only allow values that are even
const evenSource = source2.pipe(filter(isEven));

//keep a running total of the number of even numbers out
const evenNumberCount = evenSource.pipe(scan((acc, _) => acc + 1, 0));

//do not emit until 5 even numbers have been emitted
const fiveEvenNumbers = evenNumberCount.pipe(filter(val => val > 5));

const example2 = evenSource.pipe(
  //also give me the current even number count for display
  withLatestFrom(evenNumberCount),
  map(([val, count]) => `Even number (${count}) : ${val}`),
  //when five even numbers have been emitted, complete source observable
  takeUntil(fiveEvenNumbers)
);
/*
    Even number (1) : 0,
  Even number (2) : 2
    Even number (3) : 4
    Even number (4) : 6
    Even number (5) : 8
*/
const subscribe2 = example2.subscribe(val => console.log(val));
