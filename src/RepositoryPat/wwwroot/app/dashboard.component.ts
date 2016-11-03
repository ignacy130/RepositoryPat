import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Student } from './student';
import { StudentService } from './student.service';

@Component({
    selector: 'dashboard',
    templateUrl: 'app/dashboard.component.html',
})

export class DashboardComponent implements OnInit {

    students: Student[] = [];

    constructor(
        private router: Router,
        private studentsService: StudentService
    ) { }

    ngOnInit(): void {
        this.studentsService.getStudents()
            .then(students => this.students = students.slice(1, 5));
    }

    gotoDetail(student: Student): void {
        let link = ['/detail', student.id];
        this.router.navigate(link);
    }
}
