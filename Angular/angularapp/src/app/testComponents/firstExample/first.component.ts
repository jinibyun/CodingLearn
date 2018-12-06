/*
Explanation:
    0. Environment Setup
    1. Angular File Structure (Module, Service and Component)
    2. Component
    3. TypeScript Data Type and basic structure overview
*/

import { Component } from '@angular/core';

@Component({    // 데코레이터: 실행될 때 추가정보를 줘서 도움되게 하는 것
    selector: 'app-first',  // html tag로 변함. <h2>, <p>처럼 <app-first></app-first>로 적혀서 이 Angular Component와 그에 속한 html포멧이 모두 호출됨.
    // 현재 이 app-first는 app.component.html에서 호출되고 있다.
    templateUrl: './first.component.html',  // 해당 html파일을 다룸. 사실 ts하나와 html하나를 하나로 묶어서 볼 수 있다.
    styleUrls: ['./first.component.css'] // 스타일 정해줌
})
export class FirstComponent {

    // property
    // no type definition: it defauls to any
    firstName = 'John'; // type infer   // access modifier 안적으면 기본적으로 public
    lastName: string = 'Doe';
    age = 30; // similar to age:number
    status; // any type
    hasKids; // any type
    numberArray: number[]; // array
    stringArray: string[];
    mixedArray: any[];
    myTuple: [string, number, boolean];
    unusable: void;
    u: undefined;
    n: null;
    tempVar: string = 'This is a temp';

    address = {
        street: '50 main st',
        city: 'Toronto'
    };

    // method
    // NOTE: contrctor is normally used for dependency injection.
    // contructor called before output
    constructor() {
        // this.sayHello();
        console.log(this.age);
        this.hasBirthday();
        console.log(this.age);

        // error
        // this.firstName = 4;

        this.status = 'ermanent Resident';
        this.hasKids = true;
        this.numberArray = [1, 2, 3];
        this.stringArray = ['hello', 'world'];
        this.mixedArray = [true, undefined, 'hello'];
        this.myTuple = ['hello', 1, true];
        this.unusable = undefined;
        this.u = undefined;
        this.n = null;

        console.log(this.addNumber(2, 3));
    }

    sayHello() {
        console.log(`Hello ${this.firstName}`); // NOTE:  this format is supported with ` (back quote) it is in the '~' key
        // string.format(" {0} ", "hello"); similar
    }

    hasBirthday() {
        this.age += 1;
    }

    showAge() {
        return this.age + 10;
    }

    addNumber(num1: number, num2: number): number {
        return num1 = num2;
    }
}