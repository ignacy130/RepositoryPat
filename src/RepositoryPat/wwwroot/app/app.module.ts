import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StudentsComponent } from './students.component';
import { StudentService } from './student.service';
import { StudentDetailComponent } from './student-detail.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [
        AppComponent,
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