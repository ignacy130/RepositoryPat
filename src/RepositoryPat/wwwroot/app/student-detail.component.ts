import { Component, Input, OnInit } from '@angular/core';
import { Student } from './student';
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';

import { StudentService } from './student.service';

@Component({
    selector: 'student-detail',
    template: `
    <div id="student-selected">
      <div *ngIf="student" >
        <h2>{{student.firstMidName}} details!</h2>
        <div><label>id: </label>{{student.id}}</div>
        <div>
          <label>name: </label>
          <input [(ngModel)]="student.firstMidName" placeholder="firstName"/>
          <input [(ngModel)]="student.lastName" placeholder="lastName"/>
        </div>
      </div>
    </div>
    <button (click)="goBack()">Back</button>
    `
})

export class StudentDetailComponent implements OnInit {
    @Input()
    student: Student;

    constructor(
        private studentsService: StudentService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = +params['id'];
            this.studentsService.getStudent(id)
                .then(student => this.student = student);
        });
    }

    goBack(): void {
        this.location.back();
    }
}