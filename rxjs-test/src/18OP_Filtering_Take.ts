/*
Emit provided number of values before completing.
*/

/*
Why?

When you are interested in only the first emission, you want to use take. 
Maybe you want to see what the user first clicked on when they entered the page, 
or you would want to subscribe to the click event and just take the first emission. 
Another use-case is when you need to take a snapshot of data at a particular point in time 
but do not require further emissions. 
For example, a stream of user token updates, or a route guard based on a stream in an Angular application.
*/

/*
1. If you want to take a variable number of values based on some logic, or another observable, you can use takeUntil or takeWhile!
2. take is the opposite of skip where take will take the first n number of emissions while skip will skip the first n number of emissions.
*/


// 1
// RxJS v6+
import { of, interval, fromEvent } from 'rxjs';
import { take, tap } from 'rxjs/operators';

//emit 1,2,3,4,5
const source = of(1, 2, 3, 4, 5);
//take the first emitted value then complete
const example = source.pipe(take(1));
//output: 1
const subscribe = example.subscribe(val => console.log(val));


// 2. 
// RxJS v6+

//emit value every 1s
const interval$ = interval(1000);
//take the first 5 emitted values
const example2 = interval$.pipe(take(5));
//output: 0,1,2,3,4
const subscribe2 = example2.subscribe(val => console.log(val));


// 3
// RxJS v6+

const oneClickEvent = fromEvent(document, 'click').pipe(
  take(1),
  tap( (v:MouseEvent) => {
    document.getElementById(
      'locationDisplay'
    ).innerHTML = `Your first click was on location ${v.screenX}:${v.screenY}`;
  })
);

const subscribe3 = oneClickEvent.subscribe();
