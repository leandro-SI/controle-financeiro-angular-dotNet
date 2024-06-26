import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cartao } from 'src/app/models/Cartao';
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
export class CartoesService {

  constructor(private http: HttpClient) { }

  getById(id: number) : Observable<Cartao> {
    return this.http.get<Cartao>(`${environment.urlApi}Cartao/get-by-id/${id}`, httpOptions);
  }

  getByUserId(userId: string) : Observable<Cartao[]> {
    return this.http.get<Cartao[]>(`${environment.urlApi}Cartao/get-by-user/${userId}`, httpOptions);
  }

  create(cartao: Cartao) : Observable<any> {
    return this.http.post<Cartao>(`${environment.urlApi}Cartao/create`, cartao, httpOptions)
  }

  update(id: number, cartao: Cartao) : Observable<any> {
    return this.http.put<Cartao>(`${environment.urlApi}Cartao/update/${id}`, cartao, httpOptions);
  }

  delete(id: number) : Observable<any> {
    return this.http.delete<Number>(`${environment.urlApi}Cartao/delete/${id}`, httpOptions);
  }

  filtrar(nome: string) : Observable<Cartao[]> {
    return this.http.get<Cartao[]>(`${environment.urlApi}Cartao/filtrar/${nome}`)
  }

}
