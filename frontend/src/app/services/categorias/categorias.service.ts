import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  url:string = 'api/Categorias'

  constructor(private http: HttpClient) { }

  getAll() : Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.url + '/get-all')
  }

  getById(id: number) : Observable<Categoria> {
    const apiUrl = `${this.url}/get-by-id/${id}`;
    return this.http.get<Categoria>(apiUrl);
  }

  create(categoria: Categoria) : Observable<any> {
    return this.http.post<Categoria>(this.url + '/create', categoria, httpOptions)
  }

  update(id: number, categoria: Categoria) : Observable<any> {
    const apiUrl = `${this.url}/update/${id}`;
    return this.http.put<Categoria>(apiUrl, categoria, httpOptions);
  }

  delete(id: number) : Observable<any> {
    const apiUrl = `${this.url}/delete/${id}`;
    return this.http.delete<Number>(apiUrl, httpOptions);
  }
}
