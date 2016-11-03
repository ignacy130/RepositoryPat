import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: `
    <h1>{{title}}</h1>
        <nav>
            <a routerLink="/dashboard">Dashboard</a>
            <a routerLink="/students">Students</a>
        </nav>
    <router-outlet></router-outlet>
    `
})

export class AppComponent {
    title = 'Contoso University';
}