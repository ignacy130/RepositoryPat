import { Component, OnInit } from '@angular/core';
import { StudentService } from './student.service';
import { Student } from './student';

@Component({
    selector: 'my-app',
    template: `
    <h1>{{title}}</h1>
    <student-detail [student]="selectedStudent"></student-detail>
    <ul id='students-list'>
    <li *ngFor="let student of students" (click)="onSelect(student)">
    <strong>{{student.firstMidName}} {{student.lastName}} details!</strong>
      <div><label>id: </label>{{student.id}}</div>
      <div><label>name: </label>{{student.firstMidName}} {{student.lastName}}</div>
    </li>
    </ul>
    `,
    providers: [
        StudentService
    ]
})

export class AppComponent extends OnInit {

    title = 'Contoso University';

    constructor(private _service: StudentService) {
        super();
    }

    ngOnInit() {
        this._service.getStudents().then(data => {
            this.students = data;
        })
    }

    students: Student[] = [];

    selectedStudent: Student;

    onSelect(student: Student): void {
        this.selectedStudent = student;
    }
}