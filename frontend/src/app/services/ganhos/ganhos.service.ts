import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ganho } from 'src/app/models/Ganho';
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
export class GanhosService {

  constructor(private http: HttpClient) { }

  getByUserId(userId: string) : Observable<Ganho[]> {
    return this.http.get<Ganho[]>(`${environment.urlApi}Ganhos/get-by-user/${userId}`);
  }

  getById(id: number) : Observable<Ganho> {
    return this.http.get<Ganho>(`${environment.urlApi}Ganhos/get-by-id/${id}`);
  }

  create(ganho: Ganho) : Observable<any> {
    return this.http.post<Ganho>(`${environment.urlApi}Ganhos/create`, ganho, httpOptions)
  }

  update(id: number, ganho: Ganho) : Observable<any> {
    return this.http.put<Ganho>(`${environment.urlApi}Ganhos/update/${id}`, ganho, httpOptions);
  }

  delete(id: number) : Observable<any> {
    return this.http.delete<Number>(`${environment.urlApi}Ganhos/delete/${id}`, httpOptions);
  }

  filtrar(nomeCategoria: string) : Observable<Ganho[]> {
    return this.http.get<Ganho[]>(`${environment.urlApi}Ganhos/filtrar/${nomeCategoria}`)
  }

}
