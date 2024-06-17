import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tipo } from 'src/app/models/Tipo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TiposService {

  constructor(private http: HttpClient) { }

  GetAll() : Observable<Tipo[]> {
    return this.http.get<Tipo[]>(`${environment.urlApi}Tipos/get-all`);
  }

}
