/*
Discard emitted values that take less than the specified time between output
*/

// RxJS v6+
import { fromEvent } from 'rxjs';
import { debounceTime, map } from 'rxjs/operators';

// elem ref
const searchBox = document.getElementById('search');

// streams
const keyup$ = fromEvent(searchBox, 'keyup');

// wait .5s between keyups to emit current value
// NOTE: pipe functions "chains operators together"
keyup$
  .pipe(
    map((i: any) => i.currentTarget.value), // check it out documentation
    debounceTime(500)
  )
  .subscribe(console.log);
