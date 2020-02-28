/*
Operators offer a way to manipulate values from a source, returning an observable of the transformed values. Many of the RxJS operators will look familiar if you are used to JavaScripts Array methods. For instance, if you want to transform emitted values from an observable source, you can use map:
*/

/*
The pipe function is the assembly line from your observable data source through your operators. Just like raw material in a factory goes through a series of stops before it becomes a finished product, source data can pass through a pipe-line of operators where you can manipulate, filter, and transform the data to fit your use case. It's not uncommon to use 5 (or more) operators within an observable chain, contained within the pipe function.
*/

// import the from operator
import { of, fromEvent } from 'rxjs';
import { map, filter, takeUntil } from 'rxjs/operators';
/*
 *  'of' allows you to deliver values in a sequence
 *  In this case, it will emit 1,2,3,4,5 in order.
 */
const dataSource = of(1, 2, 3, 4, 5);

console.log("-----------map------------");
// subscribe to our source observable
const subscription = dataSource
  .pipe(
    // add 1 to each emitted value
    map(value => value + 1)
  )
  // log: 2, 3, 4, 5, 6
  .subscribe(value => console.log(value));

console.log("-----------filter------------");

// subscribe to our source observable
const subscription2 = dataSource
  .pipe(
    // only accept values 2 or greater
    filter(value => value >= 2)
  )
  // log: 2, 3, 4, 5
  .subscribe(value => console.log(value));

  /* pipe function */
  /*
  The pipe function is the assembly line from your observable data source through your operators. 
  Just like raw material in a factory goes through a series of stops before it becomes a finished product, 
  source data can pass through a pipe-line of operators where you can manipulate, filter, and transform the data to fit your use case. 
  It's not uncommon to use 5 (or more) operators within an observable chain, contained within the pipe function.
  */
