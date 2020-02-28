/*
After given duration, emit numbers in sequence every specified duration.
*/

// 1
// RxJS v6+
import { timer } from 'rxjs';

//emit 0 after 1 second then complete, since no second argument is supplied
const source = timer(1000);
//output: 0
const subscribe = source.subscribe(val => console.log(val));


/*
  timer takes a second argument, how often to emit subsequent values
  in this case we will emit first value after 1 second and subsequent
  values every 2 seconds after
*/
const source2 = timer(1000, 2000);
//output: 0,1,2,3,4,5......
const subscribe2 = source.subscribe(val => console.log(val));
