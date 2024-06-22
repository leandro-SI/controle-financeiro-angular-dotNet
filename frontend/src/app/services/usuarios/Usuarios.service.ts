import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcao } from 'src/app/models/Funcao';
import { LoginUsuario } from 'src/app/models/LoginUsuario';
import { RegistroUsuario } from 'src/app/models/RegistroUsuario';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json'
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
    return this.http.post<RegistroUsuario>(`${environment.urlApi}Usuario/registrar`, dadosRegistro, httpOptions)
  }

  logarUsuario(dadosLogin: LoginUsuario): Observable<any> {
    return this.http.post<RegistroUsuario>(`${environment.urlApi}Usuarios/logar`, dadosLogin, httpOptions)
  }

}
