import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule }   from '@angular/router';

import { AppComponent } from './app.component';
import { StudentsComponent } from './students.component';
import { DashboardComponent } from './dashboard.component';
import { StudentService } from './student.service';
import { StudentDetailComponent } from './student-detail.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot([
            {
                path: '',
                redirectTo: '/dashboard',
                pathMatch: 'full'
            },
            {
                path: 'dashboard',
                component: DashboardComponent
            },
            {
                path: 'students',
                component: StudentsComponent
            },
            {
                path: 'detail/:id',
                component: StudentDetailComponent
            },
        ])
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        StudentDetailComponent,
        StudentsComponent,
    ],
    providers: [
        StudentService
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule { }