import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: `
    <h1>{{title}}</h1>
    <a routerLink="/students">Students</a>
    <router-outlet></router-outlet>
    `
})

export class AppComponent {
    title = 'Contoso University';
}