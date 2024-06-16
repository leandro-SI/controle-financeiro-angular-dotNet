import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  getAll() : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${environment.urlApi}Categorias/get-all`)
  }

  getById(id: number) : Observable<Categoria> {
    return this.http.get<Categoria>(`${environment.urlApi}Categorias/get-by-id/${id}`);
  }

  create(categoria: Categoria) : Observable<any> {
    return this.http.post<Categoria>(`${environment.urlApi}Categorias/create`, categoria, httpOptions)
  }

  update(id: number, categoria: Categoria) : Observable<any> {
    return this.http.put<Categoria>(`${environment.urlApi}Categorias/update/${id}`, categoria, httpOptions);
  }

  delete(id: number) : Observable<any> {
    return this.http.delete<Number>(`${environment.urlApi}Categorias/delete/${id}`, httpOptions);
  }
}
