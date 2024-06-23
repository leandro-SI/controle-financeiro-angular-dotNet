import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetTokenUser } from 'src/app/app.module';
import { Funcao } from 'src/app/models/Funcao';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('TokenUsuario')}`
  })
};

@Injectable({
  providedIn: 'root'
})
export class FuncoesService {

constructor(private http: HttpClient) { }

  getAll() : Observable<Funcao[]> {
    return this.http.get<Funcao[]>(`${environment.urlApi}Funcoes/get-all`)
  }

  getById(id: string) : Observable<Funcao> {
    return this.http.get<Funcao>(`${environment.urlApi}Funcoes/get-by-id/${id}`);
  }

  create(funcao: Funcao) : Observable<any> {
    return this.http.post<Funcao>(`${environment.urlApi}Funcoes/create`, funcao, httpOptions)
  }
  update(id: string, funcao: Funcao) : Observable<any> {
    return this.http.put<Funcao>(`${environment.urlApi}Funcoes/update/${id}`, funcao, httpOptions);
  }

  delete(id: string) : Observable<any> {
    return this.http.delete<Number>(`${environment.urlApi}Funcoes/delete/${id}`, httpOptions);
  }

  filtrar(name: string) : Observable<Funcao[]> {
    return this.http.get<Funcao[]>(`${environment.urlApi}Funcoes/filtrar/${name}`)
  }
}
