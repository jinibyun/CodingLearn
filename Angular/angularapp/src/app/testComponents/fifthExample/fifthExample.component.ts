import { Component, OnInit } from '@angular/core';
import { User2 } from '../../models/User'; // call interface (manually create)

@Component({
  selector: 'app-fifthExample',
  templateUrl: './fifthExample.component.html',
  styleUrls: ['./fifthExample.component.css']
})
export class FifthExampleComponent implements OnInit {
  user: User2 = {
    firstName: '',
    lastName: '',
    age: null,
    address: {
      street: '',
      city: '',
      state: ''
    }
  }

  users: User2[];
  showExtended: boolean = true;
  loaded: boolean = true; // mimi data loading

  enabledAdd: boolean = false; // property binding
  showUserForm: boolean = false;
  constructor() { }

  ngOnInit() {
    this.users = [
      {
        firstName: 'John',
        lastName: 'Doe',
        age: 30,
        address: {
          street: '120 King St',
          city: 'Toronto',
          state: 'ON'
        },
        isActive: true,
        registered: new Date('01/02/2018 08:30:00'),
        hide: true
      },
      {
        firstName: 'Kevin',
        lastName: 'Johnson',
        isActive: true,
        registered: new Date('03/11/2017 08:30:00'),
        hide: false
      },
      {
        firstName: 'Caren',
        lastName: 'Williams',
        age: 26,
        address: {
          street: '123 yonge ave',
          city: 'Manitoba',
          state: 'MB'
        },
        isActive: true,
        registered: new Date('11/25/2017 10:30:00'),
        hide: true
      }
    ];
  }

  addUser() {
    // this.users.push(this.user);
    this.user.isActive = true;
    this.user.registered = new Date();
    this.users.unshift(this.user);  // unshift는 array 제일 앞쪽에 variable을 insert 하는 것이다. push를 쓰면 맨 뒤쪽에 추가한다.
    this.user = {
      firstName: '',
      lastName: '',
      age: null,
      address: {
        street: '',
        city: '',
        state: ''
      }
    }
  }

  // toggleHide(user:User2){
  //   user.hide = !user.hide;
  // }
  onSubmit(e) {
    console.log(123);
    e.preventDefault(); // 이벤트가 전체 문서에서 일어나지 않도록 막음.
    // 기본적으로 html에서 form 안의 submit타입 input은 눌리게 되면 문서 전체에 submit이벤트를 날려서 골 때림. 그걸 예방하는 트릭임.
    // 자기가 속한 form 밖으로 못나가게함
  }

  fireEvent(e) {
    console.log(e.type);
    console.log(e.target.value);
  }
}
