
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TestReq } from '../models/test-req';
import { Synthese } from '../models/synthese';
@Injectable({
    providedIn: 'root'
})
export class TreeService {

    syntheses: Synthese[];
    constructor(private http: HttpClient) { }

    create(testReq: TestReq) {
        return this.http.post(`${environment.api_host}` + "api/tree", testReq)
    }

    getAll(): Observable<any> {
        return this.http.get(`${environment.api_host}` + "api/tree")
    }
    getExport(): Observable<any> {
        return this.http.get(`${environment.api_host}` + "api/tree/export")
    }
}
