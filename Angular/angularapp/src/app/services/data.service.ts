import { Injectable } from '@angular/core'; // injectable하게 하려고 계승함
import { User3 } from '../models/User';   // 

// Observable
import { Observable, of } from 'rxjs';      // observable하게

@Injectable({
  providedIn: 'root'
})
export class DataService {

  users: User3[];
  data: Observable<any>;
  constructor() {

    this.users = [
      {
        firstName: "John",
        lastName: "Doe",
        email: 'John@gmail.com',
        isActive: true,
        registered: new Date('01/02/2018 08:30:00'),
        hide: true
      },
      {
        firstName: "Kevin",
        lastName: "Johnson",
        email: 'Kevin@gmail.com',
        isActive: true,
        registered: new Date('03/11/2017 08:30:00'),
        hide: false
      },
      {
        firstName: "Caren",
        lastName: "Williams",
        email: 'Caren@gmail.com',
        isActive: true,
        registered: new Date('11/25/2017 10:30:00'),
        hide: true
      },
      {
        firstName: "Jinin",
        lastName: "Byeon",
        email: 'Caren@gmail.com',
        isActive: true,
        registered: new Date('11/25/2017 10:30:00'),
        hide: true
      }
    ];

  }

  getUsers(): Observable<User3[]> {
    return of(this.users);  // C#의 yield return과 비슷하다. 거기선 보통 array 세팅해두고 불릴때마다 순차적으로 다른값을 보내준다.
                  // abc = ['a', 'b', 'c']면 불릴때마다 처음은 a, 그다음은 b, 그다음 c 이렇게 리턴한다.  구글링으로 yeild return 예제 참고.
                  // 모두 리턴하게 됬는데 다시 불리면 다시 처음으로 되돌아 간다.
  }

  addUser(user: User3) {
    this.users.unshift(user);
  }

  getData() {
    this.data = new Observable(observer => {
      setTimeout(() => {    // setTimeout은 타이머라 보면 됨
        observer.next(1);       // Event Publishing, Subscribing 으로 보면 됨. 여기는 Publishing 하는 중. 누가 받든 말든 무조건 신호 보냄.
                                // seventhExample.component.ts에 subscribe하는 코드가 있음. 그럼 거기는 여기서 보낸 users데이터를 받는다.
      }, 1000);

      setTimeout(() => {
        observer.next(2);
      }, 2000);

      setTimeout(() => {
        observer.next(3);
      }, 3000);

      setTimeout(() => {
        observer.next({ name: 'jini' });
      }, 4000);

    });

    return this.data;
  }


}
