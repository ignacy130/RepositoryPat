import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: `
    <h1>{{title}}</h1>
    <students>Loading...</students>
    `
})

export class AppComponent {
    title = 'Tour of Heroes';
}