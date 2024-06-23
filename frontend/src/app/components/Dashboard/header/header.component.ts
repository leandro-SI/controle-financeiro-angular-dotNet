import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../dashboard/dashboard.component.scss']
})
export class HeaderComponent implements OnInit {

  emailUsuarioLogado: string = localStorage.getItem('EmailUsuarioLogado')

  constructor(private router: Router) { }

  ngOnInit() {
  }

  EfetuarLogout() : void {
    localStorage.clear();
    this.router.navigate(['usuarios/login']);
  }

}
