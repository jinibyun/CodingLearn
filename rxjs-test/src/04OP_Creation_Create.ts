/*
Create an observable with given subscription function.
*/

// 1
import { Observable } from 'rxjs';
/*
  Create an observable that emits 'Hello' and 'World' on  
  subscription.
*/
const hello = Observable.create(function(observer: any) {
  observer.next('Hello');
  observer.next('World');
  observer.complete();
});

//output: 'Hello'...'World'
const subscribe = hello.subscribe(val => console.log(val));


// 2

/*
  Increment value every 1s, emit even numbers.
*/
const evenNumbers = Observable.create(function(observer) {
    let value = 0;
    const interval = setInterval(() => {
      if (value % 2 === 0) {
        observer.next(value);
      }
      value++;
    }, 1000);
  
    return () => clearInterval(interval);
  });
  
  //output: 0...2...4...6...8
  const subscribe2 = evenNumbers.subscribe(val => console.log(val));
  
  
  //unsubscribe after 10 seconds
  setTimeout(() => {
    subscribe2.unsubscribe();
  }, 10000);