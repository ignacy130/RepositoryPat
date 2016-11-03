import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Student } from './student';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class StudentService {
    constructor(private _http: Http) { }

    getStudents(): Promise<Student[]> {
        return this._http.get('/api/students')
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    getStudent(id: number): Promise<Student> {
        return this._http.get('/api/students/' + id)
            .toPromise()
            .then(response => response.json());
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';

        console.error(errMsg);
        return Promise.reject(errMsg);
    }
}