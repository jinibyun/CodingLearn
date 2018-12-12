import { Component, OnInit, ViewChild } from '@angular/core';
import { User3 } from '../../models/User'; // call interface 
import { DataService } from '../../services/data.service';
@Component({
  selector: 'app-seventhExample',
  templateUrl: './seventhExample.component.html',
  styleUrls: ['./seventhExample.component.css']
})
export class SeventhExampleComponent implements OnInit {
  user: User3 = {
    firstName: '',
    lastName: '',
    email: ''
  }

  users: User3[];
  showExtended: boolean = true;
  loaded: boolean = true; // mimi data loading

  enabledAdd: boolean = false; // property binding
  showUserForm: boolean = false;
  @ViewChild('userForm') form: any;
  data: any;
  // dependency injection   -> C#이나 Java에서 Interface variable = new Class(); 이런 것과 같음. Interface를 계승하는 한 Dynamic하게 class를 바꿀 수 있다. 그것과 비슷
  constructor(private dataService: DataService) {

  }

  ngOnInit() {
    // getData의 Event Publishing을 subscribe함.
    // subscribe는 라디오 주파수를 맞춰서 이벤트핸들링 한다고 보면 됨.
    // 그리고 거기서 데이터를 가져옴. F12 눌러서 Definition 참고
    // 데이터 핸들링하는 아주 Standard한 방법이라 보면 된다.
    this.dataService.getData().subscribe(data => {
      console.log(data);
    });
    this.dataService.getUsers().subscribe(users => {
      this.users = users;
      this.loaded = true;
    });
  }

  onSubmit({ value, valid }: { value: User3, valid: boolean }) {
    if (!valid) {
      console.log('Forms is not vaild');

    }
    else {
      value.isActive = true;
      value.registered = new Date();
      value.hide = true;

      this.dataService.addUser(value);
      this.form.reset();
    }
  }

}
