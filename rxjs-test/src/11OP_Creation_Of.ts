/*
Emit variable amount of values in a sequence and then emits a complete notification.
 */

 // 1
 // RxJS v6+
import { of } from 'rxjs';
//emits any number of provided values in sequence
const source = of(1, 2, 3, 4, 5);
//output: 1,2,3,4,5
const subscribe = source.subscribe(val => console.log(val));

// 2
// RxJS v6+
//emits values of any type
const source2 = of({ name: 'Brian' }, [1, 2, 3], function hello() {
  return 'Hello';
});
//output: {name: 'Brian}, [1,2,3], function hello() { return 'Hello' }
const subscribe2 = source2.subscribe(val => console.log(val));
