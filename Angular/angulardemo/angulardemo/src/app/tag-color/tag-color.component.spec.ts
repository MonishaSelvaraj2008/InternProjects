import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagColorComponent } from './tag-color.component';

describe('TagColorComponent', () => {
  let component: TagColorComponent;
  let fixture: ComponentFixture<TagColorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TagColorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TagColorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
