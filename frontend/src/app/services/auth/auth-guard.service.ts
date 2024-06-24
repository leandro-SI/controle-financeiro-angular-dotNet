import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode';
import { MyToken } from 'src/app/models/MyToken ';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

constructor(private jwtHelper: JwtHelperService,
  private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const token = localStorage.getItem('TokenUsuario');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }

    this.router.navigate(['usuarios/login']);
    return false;
  }

  VerificarAdministrador() : boolean {
    const token = localStorage.getItem('TokenUsuario');
    console.log('Role: ', jwtDecode<MyToken>(token).role)
    if (token != null) {
      const tokenUsuario = jwtDecode<MyToken>(token);
      if (tokenUsuario.role === 'Administrador')
        return true
    }
    return false;
  }

}
