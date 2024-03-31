import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TreUnoComponent } from './tre-uno.component';

describe('TreUnoComponent', () => {
  let component: TreUnoComponent;
  let fixture: ComponentFixture<TreUnoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TreUnoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TreUnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
