import { Component, Input } from '@angular/core';
import { Student } from './student';

@Component({
    selector: 'student-detail',
    template: `
      <div *ngIf="student">
        <h2>{{student.firstMidName}} details!</h2>
        <div><label>id: </label>{{student.id}}</div>
        <div>
          <label>name: </label>
          <input [(ngModel)]="student.firstMidName" placeholder="firstName"/>
          <input [(ngModel)]="student.lastName" placeholder="lastName"/>
        </div>
      </div>
    `
})

export class StudentDetailComponent {
    @Input()
    student: Student;
}