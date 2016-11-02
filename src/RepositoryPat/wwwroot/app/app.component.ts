import { Component, OnInit } from '@angular/core';
import { StudentService, Student } from './student.service';

@Component({
    selector: 'my-app',
    template: `
    <h1>My First Angular 2 App</h1>
    <ul>
    <li *ngFor="let student of students">
    <strong>{{student.lastName}}</strong><br>
    from: {{student.firstMidName}}<br>
    date of birth: {{student.enrollmentDate | date: 'dd/MM/yyyy'}}
    </li>
    </ul>
    `,
    providers: [
        StudentService
    ]
})
export class AppComponent extends OnInit {

    constructor(private _service: StudentService) {
        super();
    }

    ngOnInit() {
        this._service.loadData().then(data => {
            this.students = data;
        })
    }

    students: Student[] = [];
}
