import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyComponent1 } from './my.component1';

describe('MyComponent', () => {
  let component: MyComponent1;
  let fixture: ComponentFixture<MyComponent1>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyComponent1 ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
