import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
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
export class CategoriasService {

  constructor(private http: HttpClient) { }

  getAll() : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${environment.urlApi}Categorias/get-all`)
  }

  getById(id: number) : Observable<Categoria> {
    return this.http.get<Categoria>(`${environment.urlApi}Categorias/get-by-id/${id}`, httpOptions);
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

  filtrar(nome: string) : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${environment.urlApi}Categorias/filtrar/${nome}`)
  }

  filtrarCategoriasDespepesas() : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${environment.urlApi}Categorias/filtrar-categorias-by-despesa`)
  }

  filtrarCategoriasGanhos() : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${environment.urlApi}Categorias/filtrar-categorias-by-ganho`)
  }
}
