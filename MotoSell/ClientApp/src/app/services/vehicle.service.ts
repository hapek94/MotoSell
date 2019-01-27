
import { HttpClient  } from '@angular/common/http';

import { Injectable } from '@angular/core';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class VehicleService {

  constructor(private http: HttpClient  ) { }
  getMakes(): Observable<any[]>  {
    return this.http.get<any[]>('/api/makes');
  }

  getFeatures(): Observable<any[]> {
    return this.http.get<any[]>('/api/features');
  }
}
