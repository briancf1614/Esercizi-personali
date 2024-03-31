import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyLazyGrandChildComponent } from './my-lazy-grand-child.component';

describe('MyLazyGrandChildComponent', () => {
  let component: MyLazyGrandChildComponent;
  let fixture: ComponentFixture<MyLazyGrandChildComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyLazyGrandChildComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyLazyGrandChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
