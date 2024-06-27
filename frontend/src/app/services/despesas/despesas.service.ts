import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Despesa } from 'src/app/models/Despesa';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
  })
};

@Injectable({
  providedIn: 'root'
})
export class DespesasService {

  constructor(private http: HttpClient) { }

  getByUserId(userId: string) : Observable<Despesa[]> {
    return this.http.get<Despesa[]>(`${environment.urlApi}Despesa/get-by-user/${userId}`);
  }

  getById(id: number) : Observable<Despesa> {
    return this.http.get<Despesa>(`${environment.urlApi}Despesa/get-by-id/${id}`);
  }

  create(despesa: Despesa) : Observable<any> {
    return this.http.post<Despesa>(`${environment.urlApi}Despesa/create`, despesa, httpOptions)
  }

  update(id: number, despesa: Despesa) : Observable<any> {
    return this.http.put<Despesa>(`${environment.urlApi}Despesa/update/${id}`, despesa, httpOptions);
  }

  delete(id: number) : Observable<any> {
    return this.http.delete<Number>(`${environment.urlApi}Despesa/delete/${id}`, httpOptions);
  }

  filtrar(nomeCategoria: string) : Observable<Despesa[]> {
    return this.http.get<Despesa[]>(`${environment.urlApi}Despesa/filtrar/${nomeCategoria}`)
  }

}
