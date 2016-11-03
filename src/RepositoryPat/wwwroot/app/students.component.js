"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var student_service_1 = require('./student.service');
var StudentsComponent = (function (_super) {
    __extends(StudentsComponent, _super);
    function StudentsComponent(_service) {
        _super.call(this);
        this._service = _service;
        this.title = 'Contoso University';
        this.students = [];
    }
    StudentsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._service.getStudents().then(function (data) {
            _this.students = data;
        });
    };
    StudentsComponent.prototype.onSelect = function (student) {
        this.selectedStudent = student;
    };
    StudentsComponent = __decorate([
        core_1.Component({
            selector: 'students-app',
            template: "\n    <h1>{{title}}</h1>\n    <student-detail [student]=\"selectedStudent\"></student-detail>\n    <ul id='students-list'>\n    <li *ngFor=\"let student of students\" (click)=\"onSelect(student)\">\n    <strong>{{student.firstMidName}} {{student.lastName}} details!</strong>\n      <div><label>id: </label>{{student.id}}</div>\n      <div><label>name: </label>{{student.firstMidName}} {{student.lastName}}</div>\n    </li>\n    </ul>\n    ",
            providers: [
                student_service_1.StudentService
            ]
        }), 
        __metadata('design:paramtypes', [student_service_1.StudentService])
    ], StudentsComponent);
    return StudentsComponent;
}(core_1.OnInit));
exports.StudentsComponent = StudentsComponent;
//# sourceMappingURL=students.component.js.map