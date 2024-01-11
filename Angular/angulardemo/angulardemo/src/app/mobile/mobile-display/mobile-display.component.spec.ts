import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MobileDIsplayComponent } from './mobile-display.component';

describe('MobileDIsplayComponent', () => {
  let component: MobileDIsplayComponent;
  let fixture: ComponentFixture<MobileDIsplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MobileDIsplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MobileDIsplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
