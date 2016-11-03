import { Component, OnInit } from '@angular/core';

import { Student } from './student';
import { StudentService } from './student.service';

@Component({
    selector: 'dashboard',
    templateUrl: 'app/dashboard.component.html',
})

export class DashboardComponent implements OnInit {

    students: Student[] = [];

    constructor(private studentsService: StudentService) { }

    ngOnInit(): void {
        this.studentsService.getStudents()
            .then(students => this.students = students.slice(1, 5));
    }

    gotoDetail(student: Student): void { /* not implemented yet */ }
}
