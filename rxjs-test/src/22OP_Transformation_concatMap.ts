/*
Map values to inner observable, subscribe and emit in order.
*/

// RxJS v6+
import { of } from 'rxjs';
import { concatMap, delay, mergeMap } from 'rxjs/operators';

//emit delay value
const source = of(2000, 1000);
// map value from source into inner observable, when complete emit result and move to next
const example = source.pipe(
  concatMap(val => of(`Delayed by: ${val}ms`).pipe(delay(val)))
);
//output: With concatMap: Delayed by: 2000ms, With concatMap: Delayed by: 1000ms
const subscribe = example.subscribe(val =>
  console.log(`With concatMap: ${val}`)
);

// showing the difference between concatMap and mergeMap
/*
Because concatMap does not subscribe to the next observable until the previous completes, 
the value from the source delayed by 2000ms will be emitted first. Contrast this with mergeMap 
which subscribes immediately to inner observables, the observable with the lesser delay (1000ms) will emit, 
followed by the observable which takes 2000ms to complete.
*/
const mergeMapExample = source
  .pipe(
    // just so we can log this after the first example has run
    delay(5000),
    mergeMap(val => of(`Delayed by: ${val}ms`).pipe(delay(val)))
  )
  .subscribe(val => console.log(`With mergeMap: ${val}`));


  // 2. Map to promise
  //emit 'Hello' and 'Goodbye'
const source2 = of('Hello', 'Goodbye');
//example with promise
const examplePromise = val => new Promise(resolve => resolve(`${val} World!`));
// map value from source into inner observable, when complete emit result and move to next
const example2 = source2.pipe(concatMap(val => examplePromise(val)));
//output: 'Example w/ Promise: 'Hello World', Example w/ Promise: 'Goodbye World'
const subscribe2 = example2.subscribe(val =>
  console.log('Example w/ Promise:', val)
);


// 3. supplying a projection function
//emit 'Hello' and 'Goodbye'
const source3 = of('Hello', 'Goodbye');
//example with promise
const examplePromise2 = val => new Promise(resolve => resolve(`${val} World!`));
//result of first param passed to second param selector function before being  returned
const example3 = source3.pipe(
  concatMap(val => examplePromise2(val), result => `${result} w/ selector!`)
);
//output: 'Example w/ Selector: 'Hello w/ Selector', Example w/ Selector: 'Goodbye w/ Selector'
const subscribe3 = example3.subscribe(val =>
  console.log('Example w/ Selector:', val)
  );