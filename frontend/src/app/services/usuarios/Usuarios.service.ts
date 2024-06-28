import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcao } from 'src/app/models/Funcao';
import { LoginUsuario } from 'src/app/models/LoginUsuario';
import { RegistroUsuario } from 'src/app/models/RegistroUsuario';
import { UpdateUsuario } from 'src/app/models/UpdateUsuario';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json'
  })
};

const httpOptionsEdit = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
  })
};

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http: HttpClient) { }

  salvarFoto(formData: any) : Observable<any> {
    return this.http.post<any>(`${environment.urlApi}Usuario/save-foto`, formData);
  }

  registrarUsuario(dadosRegistro: RegistroUsuario) : Observable<any> {
    return this.http.post<RegistroUsuario>(`${environment.urlApi}Authentication/registrar`, dadosRegistro, httpOptions)
  }

  logarUsuario(dadosLogin: LoginUsuario): Observable<any> {
    return this.http.post<RegistroUsuario>(`${environment.urlApi}Authentication/logar`, dadosLogin, httpOptions)
  }

  getFotoUsuario(userId: string) : Observable<any> {
    return this.http.get<any>(`${environment.urlApi}Usuario/get-foto/${userId}`)
  }

  getById(id: string) : Observable<UpdateUsuario> {
    return this.http.get<UpdateUsuario>(`${environment.urlApi}Usuario/get/${id}`)
  }

  update(usuario: UpdateUsuario) : Observable<any> {
    return this.http.put<UpdateUsuario>(`${environment.urlApi}Usuario/update`, usuario, httpOptionsEdit)
  }

}
