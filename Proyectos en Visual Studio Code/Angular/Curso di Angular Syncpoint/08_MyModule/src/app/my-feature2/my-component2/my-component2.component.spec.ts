import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyComponent2 } from './my-component2.component';

describe('MyComponent2', () => {
  let component: MyComponent2;
  let fixture: ComponentFixture<MyComponent2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyComponent2 ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyComponent2);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
