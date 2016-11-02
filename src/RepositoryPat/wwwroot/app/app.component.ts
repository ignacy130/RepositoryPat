import { Component, OnInit } from '@angular/core';
import { StudentService, Student } from './student.service';

@Component({
    selector: 'my-app',
    template: `
    <h1>{{title}}</h1>
    <ul>
    <li *ngFor="let student of students">
    <h2>{{student.firstMidName}} {{student.lastName}} details!</h2>
      <div><label>id: </label>{{student.id}}</div>
      <div><label>first name: </label>{{student.firstMidName}}</div>
      <div><label>last name: </label>{{student.lastName}}</div>
      <div> NAME
        <input [(ngModel)]="student.firstMidName" placeholder="name">
      </div>  
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
        this._service.loadData().then(data => {
            this.students = data;
        })
    }

    students: Student[] = [];
}