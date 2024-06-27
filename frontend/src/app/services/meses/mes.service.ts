import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mes } from 'src/app/models/Mes';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MesesService {

constructor(private http: HttpClient) { }

  getAll() : Observable<Mes[]> {
    return this.http.get<Mes[]>(`${environment.urlApi}Mes/get-all`)
  }

}
