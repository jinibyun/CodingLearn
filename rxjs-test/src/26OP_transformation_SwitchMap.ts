/*
Map to observable, complete previous inner observable, emit values.
*/
/*
If you would like more than one inner subscription to be maintained, try mergeMap!
This operator is generally considered a safer default to mergeMap!
This operator can cancel in-flight network requests!
*/

/*
The main difference between switchMap and other flattening operators is the cancelling effect. 
On each emission the previous inner observable (the result of the function you supplied) is cancelled and the new observable is subscribed. 

Remember, switchMap maintains only one inner subscription at a time

NOTE:

Be careful though, you probably want to avoid switchMap in scenarios where every request needs to complete, 
think writes to a database. switchMap could cancel a request if the source emits quickly enough. In these scenarios mergeMap is the correct option.
*/


// 1: Restart interval on every click
// RxJS v6+
import { interval, fromEvent, merge, empty } from 'rxjs';
import { switchMap, mapTo, startWith, scan, takeWhile } from 'rxjs/operators';

fromEvent(document, 'click')
  .pipe(
    // restart counter on every click
    switchMap(() => interval(1000))
  )
  .subscribe(console.log);


  // 2: Countdown timer with pause and resume
  // RxJS v6+

const COUNTDOWN_SECONDS = 10;

// elem refs
const remainingLabel = document.getElementById('remaining');
const pauseButton = document.getElementById('pause');
const resumeButton = document.getElementById('resume');

// streams
const interval$ = interval(1000).pipe(mapTo(-1));
const pause$ = fromEvent(pauseButton, 'click').pipe(mapTo(false));
const resume$ = fromEvent(resumeButton, 'click').pipe(mapTo(true));

const timer$ = merge(pause$, resume$)
  .pipe(
    startWith(true),
    switchMap(val => (val ? interval$ : empty())),
    scan((acc, curr) => (curr ? curr + acc : acc), COUNTDOWN_SECONDS),
    takeWhile(v => v >= 0)
  )
  .subscribe((val: any) => (remainingLabel.innerHTML = val));
