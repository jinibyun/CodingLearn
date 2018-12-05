import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RxJsExampleComponent } from './rx-js-example.component';

describe('RxJsExampleComponent', () => {
  let component: RxJsExampleComponent;
  let fixture: ComponentFixture<RxJsExampleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RxJsExampleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RxJsExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
