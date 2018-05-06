var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
var CreateMP = /** @class */ (function () {
    function CreateMP(http) {
        this.http = http;
    }
    CreateMP.prototype.CreateFacility = function () {
        var _this = this;
        console.log(this.facility);
        this.http.fetch('api/Facilities', {
            method: 'post',
            body: JSON.stringify(this.facility),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(function (response) {
            // do whatever here
            delete _this.facility;
            console.log(response);
        }).catch(function (error) { return console.log(error); });
    };
    CreateMP = __decorate([
        inject(HttpClient),
        __metadata("design:paramtypes", [HttpClient])
    ], CreateMP);
    return CreateMP;
}());
export { CreateMP };
//# sourceMappingURL=create.js.map