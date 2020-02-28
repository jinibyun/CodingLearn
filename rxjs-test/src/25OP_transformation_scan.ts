/*
Reduce over time.
*/

// RxJS v6+
import { of, interval } from 'rxjs';
import { scan, map, distinctUntilChanged, delay, mergeMap } from 'rxjs/operators';
import { Subject } from 'rxjs';

// 1
const source = of(1, 2, 3);
// basic scan example, sum over time starting with zero
const example = source.pipe(scan((acc, curr) => acc + curr, 0));
// log accumulated values
// output: 1,3,6
const subscribe = example.subscribe(val => console.log(val));


// 2: Accumulating an object
// RxJS v6+
const subject = new Subject();
//scan example building an object over time
const example2 = subject.pipe(scan((acc, curr) => Object.assign({}, acc, curr), {})
);
//log accumulated values
const subscribe2 = example2.subscribe(val =>
console.log('Accumulated object:', val)
);
//next values into subject, adding properties to object
// {name: 'Joe'}
subject.next({ name: 'Joe' });
// {name: 'Joe', age: 30}
subject.next({ age: 30 });
// {name: 'Joe', age: 30, favoriteLanguage: 'JavaScript'}
subject.next({ favoriteLanguage: 'JavaScript' });

// 3. Emitting random values from the accumulated array
// RxJS v6+

// Accumulate values in an array, emit random values from this array.
const scanObs = interval(1000)
  .pipe(
    scan((a, c) => [...a, c], []),
    map(r => r[Math.floor(Math.random() * r.length)]),
    distinctUntilChanged()
  )
  .subscribe(console.log);

  // 4 Accumulating http responses over time
  // RxJS v6+

// const fakeRequest = of('response').pipe(delay(2000));

// // output:
// // ['response'],
// // ['response','response'],
// // ['response','response','response'],
// // etc...

// interval(1000)
//   .pipe(
//     mergeMap(_ => fakeRequest),
//     scan<string>((all, current) => [...all, current], [])
//   )
//   .subscribe(console.log);
